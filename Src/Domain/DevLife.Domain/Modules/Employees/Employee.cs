using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;


namespace DevLife.Domain.Modules.Employees;

public class Employee : AuditableBaseEntity
{
    public required Guid EmployeeNameId { get; set; }
    public required int Salary { get; set; }
    public required int Experience { get; set; }
    public required int Level { get; set; }
    public required int CFrontEnd { get; set; }
    public required int CBackEnd { get; set; }
    public required int CDevops { get; set; }
    public required int CDatabase { get; set; }
    public required bool IsAvalaible { get; set; }


    // Relation
    public required EmployeeName EmployeeName { get; set; }
    public required ICollection<EmployeeSkill>? EmployeeSkills { get; set; }
    public required CompanyEmployee CompanyEmployee { get; set; }
   
}
