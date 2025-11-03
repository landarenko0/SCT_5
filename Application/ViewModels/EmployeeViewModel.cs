using Core.Models;
using Core.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.ViewModels
{
    public class EmployeeViewModel(IEmployeesRepository employeesRepository, ILogger<EmployeeViewModel> logger)
    {
        public event Action<string>? OnError = null;

        public event Action? OnCloseForm = null;

        public event Action<bool>? UpdateButtonState = null;

        public Employee? Employee { get; set; }

        public static string RandomFirstName
        {
            get
            {
                List<string> firstNames = ["Михаил", "Андрей", "Евгений", "Виктор", "Георгий", "Владислав", "Никита", "Артем"];
                return firstNames[new Random().Next(firstNames.Count)];
            }
        }

        public static string RandomLastName
        {
            get
            {
                List<string> lastNames = ["Горшенев", "Князев", "Печеночкин", "Цой", "Остапов", "Вонг", "Редфилд", "Кэннеди"];
                return lastNames[new Random().Next(lastNames.Count)];
            }
        }

        public static int RandomSalary => new Random().Next(80000, 110000);

        private const string AlreadyExistsPgExceptionCode = "23505";

        private const string SalaryConstraintPgExceptionCode = "23514";

        public void OnSaveButtonClick(string firstName, string lastName, string salary)
        {
            if (!ValidateInput(firstName, lastName, salary)) return;

            UpdateButtonState?.Invoke(false);

            Employee employee = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = int.Parse(salary)
            };

            Task.Run(async () =>
            {
                if (Employee is null)
                {
                    if (await CreateEmployee(employee)) OnCloseForm?.Invoke();
                } 
                else
                {
                    employee.Id = Employee.Id;
                    if (await UpdateEmployee(employee)) OnCloseForm?.Invoke();
                }

                UpdateButtonState?.Invoke(true);
            });
        }

        private bool ValidateInput(string firstName, string lastName, string salary)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrEmpty(firstName))
            {
                OnError?.Invoke("Введите имя сотрудника");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrEmpty(lastName))
            {
                OnError?.Invoke("Введите фамилию сотрудника");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(salary) || string.IsNullOrEmpty(salary))
            {
                OnError?.Invoke("Введите зарплату сотрудника");
                return false;
            }
            else if (!int.TryParse(salary, out int result) /*|| result <= 0*/) // Отключено для проверки ограничения в БД
            {
                OnError?.Invoke("Некорректная зарплата");
                return false;
            }

            return true;
        }

        private async Task<bool> CreateEmployee(Employee employee)
        {
            try
            {
                await employeesRepository.CreateEmployee(employee);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured while SaveEmployee() was executing");

                if (CheckExceptionContainsCode(e, AlreadyExistsPgExceptionCode))
                {
                    OnError?.Invoke("Сотрудник с данными именем и фамилией уже существует");
                }
                else if (CheckExceptionContainsCode(e, SalaryConstraintPgExceptionCode))
                {
                    OnError?.Invoke("Зарплата должна быть больше 0");
                }
                else OnError?.Invoke("Произошла ошибка");

                return false;
            }
        }

        private async Task<bool> UpdateEmployee(Employee employee)
        {
            try
            {
                await employeesRepository.UpdateEmployee(employee);
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured while UpdateEmployee() was executing");

                if (CheckExceptionContainsCode(e, AlreadyExistsPgExceptionCode))
                {
                    OnError?.Invoke("Сотрудник с данными именем и фамилией уже существует");
                }
                else if (CheckExceptionContainsCode(e, SalaryConstraintPgExceptionCode))
                {
                    OnError?.Invoke("Зарплата должна быть больше 0");
                }
                else OnError?.Invoke("Произошла ошибка");

                return false;
            }
        }

        private static bool CheckExceptionContainsCode(Exception exception, string exceptionCode)
        {
            if (exception.Message.Contains(exceptionCode)) return true;
            else if (exception.InnerException is not null && exception.InnerException.Message.Contains(exceptionCode)) return true;

            return false;
        }
    }
}
