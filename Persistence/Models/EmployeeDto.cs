﻿namespace Persistence.Models;

public partial class EmployeeDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Salary { get; set; }
}
