using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models.Mappers;

namespace Persistence.Repositories
{
    public class EmployeesRepository(CarServiceContext context) : IEmployeesRepository
    {
        public async Task CreateEmployee(Employee employee)
        {
            await context.Employees.AddAsync(employee.ToDto());
            await context.SaveChangesAsync();
        }

        public Task UpdateEmployee(Employee employee) => context.Employees
            .Where(e => e.Id == employee.Id)
            .ExecuteUpdateAsync(propertyCalls => propertyCalls
                .SetProperty(e => e.FirstName, employee.FirstName)
                .SetProperty(e => e.LastName, employee.LastName)
                .SetProperty(e => e.Salary, employee.Salary)
            );

        public Task DeleteEmployee(int employeeId) => context.Employees.Where(e => e.Id == employeeId).ExecuteDeleteAsync();

        public Task<List<Employee>> GetAllEmployees() => context.Employees.AsNoTracking().Select(e => e.ToDomain()).ToListAsync();

        public Task<Employee?> GetEmployeeById(int employeeId) => context.Employees.AsNoTracking().Where(e => e.Id == employeeId).Select(e => e.ToDomain()).FirstOrDefaultAsync();
    }
}
