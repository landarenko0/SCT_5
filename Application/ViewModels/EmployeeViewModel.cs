using Core.Models;
using Core.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.ViewModels
{
    public class EmployeeViewModel(IEmployeesRepository employeesRepository, ILogger<EmployeeViewModel> logger)
    {
        public Action<string>? OnError = null;

        public Action? OnCloseForm = null;

        public Action<bool>? UpdateButtonState = null;

        public Employee? Employee { get; set; }

        private const string AlreadyExistsPgExceptionCode = "23505";

        public void OnSaveButtonClick(string firstName, string lastName, string salary)
        {
            if (!ValidateInput(firstName, lastName, salary)) return;

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
            else if (!int.TryParse(salary, out int result) || result <= 0)
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

                if (e.Message.Contains(AlreadyExistsPgExceptionCode))
                {
                    OnError?.Invoke("Сотрудник с данными именем и фамилией уже существует");
                }
                else if (e.InnerException is not null && e.InnerException.Message.Contains(AlreadyExistsPgExceptionCode))
                {
                    OnError?.Invoke("Сотрудник с данными именем и фамилией уже существует");
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

                if (e.Message.Contains(AlreadyExistsPgExceptionCode))
                {
                    OnError?.Invoke("Сотрудник с данными именем и фамилией уже существует");
                }
                else if (e.InnerException is not null && e.InnerException.Message.Contains(AlreadyExistsPgExceptionCode))
                {
                    OnError?.Invoke("Сотрудник с данными именем и фамилией уже существует");
                }
                else OnError?.Invoke("Произошла ошибка");

                return false;
            }
        }
    }
}
