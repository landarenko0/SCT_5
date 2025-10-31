using Core.Models;

namespace Core.Repositories
{
    public interface IEmployeesRepository
    {
        public Task<List<Employee>> GetAllEmployees();

        public Task CreateEmployee(Employee employee);

        public Task UpdateEmployee(Employee employee);

        public Task DeleteEmployee(int employeeId);
    }
}
