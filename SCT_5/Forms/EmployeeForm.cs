using Application.ViewModels;
using Core.Models;

namespace SCT_5.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeViewModel _employeeViewModel;

        private event Action OnSaveButtonClick;

        public EmployeeForm(EmployeeViewModel employeeViewModel, Action onSaveButtonClick)
        {
            InitializeComponent();

            Text = "Создание сотрудника";

            _employeeViewModel = employeeViewModel;
            OnSaveButtonClick += onSaveButtonClick;

            RegisterEvents();
            FormClosing += (_, _) => UnregisterEvents();
        }

        public EmployeeForm(EmployeeViewModel employeeViewModel, Employee employee, Action onSaveButtonClick)
        {
            InitializeComponent();

            Text = "Редактирование сотрудника";

            firstNameTextBox.Text = employee.FirstName;
            lastNameTextBox.Text = employee.LastName;
            salaryTextBox.Text = employee.Salary.ToString();

            _employeeViewModel = employeeViewModel;
            _employeeViewModel.Employee = employee;
            OnSaveButtonClick += onSaveButtonClick;

            RegisterEvents();
            FormClosing += (_, _) => UnregisterEvents();
        }

        private void RegisterEvents()
        {
            _employeeViewModel.OnError += ShowErrorDialog;
            _employeeViewModel.OnCloseForm += CloseForm;
            _employeeViewModel.UpdateButtonState += UpdateButtonState;
        }

        private void UnregisterEvents()
        {
            _employeeViewModel.OnError -= ShowErrorDialog;
            _employeeViewModel.OnCloseForm -= CloseForm;
            _employeeViewModel.UpdateButtonState -= UpdateButtonState;
        }

        private void ShowErrorDialog(string description) => MessageBox.Show(description, "Ошибка", MessageBoxButtons.OK);

        private void CloseForm()
        {
            OnSaveButtonClick();
            Close();
        }

        private void UpdateButtonState(bool isActive) => saveButton.Enabled = isActive;

        private void OnSaveEmployeeButtonClick(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string salary = salaryTextBox.Text;

            _employeeViewModel.OnSaveButtonClick(firstName, lastName, salary);
        }
    }
}
