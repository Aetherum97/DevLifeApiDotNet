using System;
using DevLife.Domain.Commons.Bases;

namespace DevLife.Domain.Modules.Employees;

public class EmployeeSkillModificator : AuditableBaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Modificator { get; set; }

    // Relation
    public ICollection<EmployeeSkill>? EmployeeSkills {get; set;}

}
