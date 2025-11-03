namespace Persistence.Models;

internal partial class EmployeeDto
{
    internal int Id { get; set; }

    internal string FirstName { get; set; } = null!;

    internal string LastName { get; set; } = null!;

    internal int Salary { get; set; }
}
