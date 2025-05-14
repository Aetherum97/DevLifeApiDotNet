using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;

namespace DevLife.Domain.Modules.Employees;

public class EmployeeName : AuditableBaseEntity
{
    public required string Name { get; set; }

    // Relation
    public ICollection<Employee>? Employees {get; set;}
}
