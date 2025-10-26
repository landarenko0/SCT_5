using Application.Abstractions;
using Core.Models;

namespace SCT_5.Forms
{
    public partial class EmployeesForm : Form
    {
        private readonly IEmployeesService _employeesService;

        private List<Employee> _employees = [];

        public EmployeesForm(IEmployeesService employeesService)
        {
            InitializeComponent();

            updateEmployeeButton.Enabled = false;
            deleteEmployeeButton.Enabled = false;

            _employeesService = employeesService;

            Task.Run(SetEmployeesInfoToGrid);
        }

        private async Task SetEmployeesInfoToGrid()
        {
            _employees = await _employeesService.GetAllEmployees();

            foreach (Employee employee in _employees)
            {
                employeesGrid.Invoke(() => employeesGrid.Rows.Add(employee.Id, employee.FirstName, employee.LastName, employee.Salary));
            }
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateEmployeeButton.Enabled = true;
            deleteEmployeeButton.Enabled = true;
        }

        private void OnDeleteEmployeeButtonClick(object sender, EventArgs e)
        {
            Employee selectedEmployee = _employees[employeesGrid.CurrentRow.Index];

            DialogResult result = MessageBox.Show(
                $"Вы действительно хотите удалить сотрудника {selectedEmployee.LastName} {selectedEmployee.FirstName}?",
                "Подтвердите действие",
                MessageBoxButtons.YesNoCancel
            );

            if (result == DialogResult.Yes)
            {
                employeesGrid.Rows.Clear();

                Task.Run(async () =>
                {
                    await DeleteEmployee(selectedEmployee.Id);
                    await SetEmployeesInfoToGrid();
                });
            }
        }

        private Task DeleteEmployee(int employeeId) => _employeesService.DeleteEmployee(employeeId);
    }
}
