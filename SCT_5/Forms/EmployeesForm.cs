using Application.Abstractions;
using Core.Models;

namespace SCT_5.Forms
{
    public partial class EmployeesForm : Form
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesForm(IEmployeesService employeesService)
        {
            InitializeComponent();

            _employeesService = employeesService;

            Task.Run(SetEmployeesInfoToGrid);
        }

        private async Task SetEmployeesInfoToGrid()
        {
            List<Employee> employees = await _employeesService.GetAllEmployees();
            foreach (Employee employee in employees) employeesGrid.Rows.Add(employee.Id, employee.FirstName, employee.LastName, employee.Salary);
        }
    }
}
