using Application.ViewModels;
using Core.Models;
using SCT_5.Factories;

namespace SCT_5.Forms
{
    public partial class EmployeesForm : Form
    {
        private readonly EmployeesViewModel _employeesViewModel;

        private readonly EmployeeFormFactory _employeeFormFactory;

        public EmployeesForm(EmployeesViewModel employeesViewModel, EmployeeFormFactory employeeFormFactory)
        {
            InitializeComponent();

            updateEmployeeButton.Enabled = false;
            deleteEmployeeButton.Enabled = false;

            _employeesViewModel = employeesViewModel;
            _employeeFormFactory = employeeFormFactory;

            _employeesViewModel.OnError += ShowErrorDialog;
            _employeesViewModel.OnEmployeesChanged += UpdateEmployeesTable;
            _employeesViewModel.UpdateButtonsState += UpdateButtonsState;
            _employeesViewModel.ClearEmployeesTable += ClearEmployeesTable;

            FormClosing += (_, _) =>
            {
                _employeesViewModel.OnError -= ShowErrorDialog;
                _employeesViewModel.OnEmployeesChanged -= UpdateEmployeesTable;
                _employeesViewModel.UpdateButtonsState -= UpdateButtonsState;
                _employeesViewModel.ClearEmployeesTable -= ClearEmployeesTable;
            };
        }

        private void ShowErrorDialog(string description) => MessageBox.Show(description, "Ошибка", MessageBoxButtons.OK);

        private void UpdateEmployeesTable(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                employeesGrid.Rows.Add(employee.Id, employee.FirstName, employee.LastName, employee.Salary);
            }
        }

        private void UpdateButtonsState(bool isActive)
        {
            updateEmployeeButton.Enabled = isActive;
            deleteEmployeeButton.Enabled = isActive;
        }

        private void ClearEmployeesTable() => employeesGrid.Rows.Clear();

        private void OnDeleteEmployeeButtonClick(object sender, EventArgs e)
        {
            Employee? selectedEmployee = _employeesViewModel.GetSelectedEmployee(employeesGrid.CurrentRow.Index);
            if (selectedEmployee == null) return;

            DialogResult result = MessageBox.Show(
                $"Вы действительно хотите удалить сотрудника {selectedEmployee.LastName} {selectedEmployee.FirstName}?",
                "Подтвердите действие",
                MessageBoxButtons.YesNoCancel
            );

            if (result == DialogResult.Yes) _employeesViewModel.OnDeleteEmployeeConfirmed(employeesGrid.CurrentRow.Index);
        }

        private void OnCreateEmployeeButtonClick(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = _employeeFormFactory.CreateForm(_employeesViewModel.OnEmployeeFormSaveButtonClicked);
            employeeForm.ShowDialog();
        }

        private void OnEditEmployeeButtonClick(object sender, EventArgs e)
        {
            Employee? selectedEmployee = _employeesViewModel.GetSelectedEmployee(employeesGrid.CurrentRow.Index);
            if (selectedEmployee == null) return;

            EmployeeForm employeeForm = _employeeFormFactory.CreateForm(_employeesViewModel.OnEmployeeFormSaveButtonClicked, selectedEmployee);
            employeeForm.ShowDialog();
        }
    }
}
