using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;

namespace DevLife.Domain.Modules.Employees;

public class EmployeeSkill : AuditableBaseEntity
{
    public required string Name {get; set;}
    public required string Description {get; set;}

    // Relation
    public ICollection<Employee>?  Employees {get; set;}
    public ICollection<EmployeeSkillModificator>? SkillModificators {get; set;}


}
