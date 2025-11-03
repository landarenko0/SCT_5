using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models.Mappers;

namespace Persistence.Repositories
{
    public class EmployeesRepository(IDbContextFactory<CarServiceContext> contextFactory) : IEmployeesRepository
    {
        public async Task CreateEmployee(Employee employee)
        {
            await using CarServiceContext context = await contextFactory.CreateDbContextAsync();

            await context.Employees.AddAsync(employee.ToDto());
            await context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await using CarServiceContext context = await contextFactory.CreateDbContextAsync();

            await context.Employees
                .Where(e => e.Id == employee.Id)
                .ExecuteUpdateAsync(propertyCalls => propertyCalls
                    .SetProperty(e => e.FirstName, employee.FirstName)
                    .SetProperty(e => e.LastName, employee.LastName)
                    .SetProperty(e => e.Salary, employee.Salary)
                );
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await using CarServiceContext context = await contextFactory.CreateDbContextAsync();
            await context.Employees.Where(e => e.Id == employeeId).ExecuteDeleteAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            await using CarServiceContext context = await contextFactory.CreateDbContextAsync();

            return await context.Employees
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Select(e => e.ToDomain())
                .ToListAsync();
        }
    }
}
