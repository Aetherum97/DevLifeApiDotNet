using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Domain.Commons.Entity;

public class Employee : AuditableBaseEntity
{

    public Guid CompanyId { get; set; }
    public Guid NameId { get; set; }
    public required int Salary { get; set; }
    public required int Experience { get; set; }
    public required int Level { get; set; }
    public required int CFrontEnd { get; set; }
    public required int CBackEnd { get; set; }
    public required int CDevops { get; set; }
    public required int CDatabase { get; set; }
    public required bool IsAvalaible { get; set; }


    // Relation
    public Company? Company { get; set; }
    public EmployeeName? EmployeeName {get; set;}
    public ICollection<EmployeeSkill>? EmployeeSkills {get; set;}
    // TODO contract and material relation

}
