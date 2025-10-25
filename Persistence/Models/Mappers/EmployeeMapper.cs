using Core.Models;

namespace Persistence.Models.Mappers
{
    internal static class EmployeeMapper
    {
        internal static Employee ToDomain(this EmployeeDto employee) => new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Salary = employee.Salary
        };

        internal static EmployeeDto ToDto(this Employee employee) => new()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Salary = employee.Salary
        };
    }
}
