using Core.Models;

namespace Application.Abstractions
{
    public interface IEmployeesService
    {
        public Task<List<Employee>> GetAllEmployees();

        public Task CreateEmployee(Employee employee);

        public Task UpdateEmployee(Employee employee);

        public Task DeleteEmployee(int employeeId);
    }
}
