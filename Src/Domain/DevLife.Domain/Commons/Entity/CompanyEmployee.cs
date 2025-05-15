using System;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Domain.Commons.Entity;

public class CompanyEmployee
{
    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
}
