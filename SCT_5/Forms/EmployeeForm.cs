using Application.Abstractions;
using Core.Exceptions;
using Core.Models;

namespace SCT_5.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly IEmployeesService _employeesService;

        private event Action OnSaveButtonClick;

        private readonly Employee? _employee = null;

        public EmployeeForm(IEmployeesService employeesService, Action onSaveButtonClick)
        {
            InitializeComponent();

            Text = "Создание сотрудника";

            _employeesService = employeesService;
            OnSaveButtonClick += onSaveButtonClick;
        }

        public EmployeeForm(IEmployeesService employeesService, Employee employee, Action onSaveButtonClick)
        {
            InitializeComponent();

            Text = "Редактирование сотрудника";

            firstNameTextBox.Text = employee.FirstName;
            lastNameTextBox.Text = employee.LastName;
            salaryTextBox.Text = employee.Salary.ToString();

            _employeesService = employeesService;
            _employee = employee;
            OnSaveButtonClick += onSaveButtonClick;
        }

        private void OnSaveEmployeeButtonClick(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string salary = salaryTextBox.Text;

            try
            {
                ValidateInput(firstName, lastName, salary);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK);
                return;
            }

            Employee employee = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = int.Parse(salary)
            };

            if (_employee is null) Task.Run(async () => await SaveEmployee(employee, _employeesService.CreateEmployee));
            else
            {
                employee.Id = _employee.Id;

                Task.Run(async () => await SaveEmployee(employee, _employeesService.UpdateEmployee));
            }
        }

        private static void ValidateInput(string firstName, string lastName, string salary)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrEmpty(firstName))
            {
                throw new Exception("Введите имя сотрудника");
            }
            else if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrEmpty(lastName))
            {
                throw new Exception("Введите фамилию сотрудника");
            }
            else if (string.IsNullOrWhiteSpace(salary) || string.IsNullOrEmpty(salary))
            {
                throw new Exception("Введите зарплату сотрудника");
            }
            else if (!int.TryParse(salary, out int result) || result <= 0)
            {
                throw new Exception("Некорректная зарплата");
            }
        }

        private async Task SaveEmployee(Employee employee, Func<Employee, Task> saveAction)
        {
            saveButton.Invoke(() => { saveButton.Enabled = false; });
            saveButton.Invoke(() => { saveButton.Text = "Подождите..."; });
            
            try
            {
                await saveAction(employee);

                OnSaveButtonClick();
                Invoke(Close);
                return;
            }
            catch (AlreadyExistsException)
            {
                Invoke(() => { MessageBox.Show("Сотрудник с заданными именем и фамилией уже существует", "Ошибка"); });
            }
            catch
            {
                Invoke(() => { MessageBox.Show("Произошла ошибка во время выполнения. Попробуйте позже", "Ошибка"); });
            }

            saveButton.Invoke(() => { saveButton.Enabled = true; });
            saveButton.Invoke(() => { saveButton.Text = "Сохранить"; });
        }
    }
}
