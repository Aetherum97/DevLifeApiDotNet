using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Contracts.Entity;
using DevLife.Domain.Modules.Materials.Entity;

namespace DevLife.Domain.Modules.Employees;

public class Employee : AuditableBaseEntity
{

    public Guid CompanyId { get; set; }
    public Guid EmployeeNameId { get; set; }
    public required int Salary { get; set; }
    public required int Experience { get; set; }
    public required int Level { get; set; }
    public required int CFrontEnd { get; set; }
    public required int CBackEnd { get; set; }
    public required int CDevops { get; set; }
    public required int CDatabase { get; set; }
    public required bool IsAvalaible { get; set; }


    // Relation
    public CompanyEmployee? CompanyEmployee { get; set; }
    public ICollection<CompanyContractEmployee>? CompanyContractEmployees { get; set; }
    public ICollection<CompanyMaterialEmployee>? CompanyMaterialEmployees { get; set; }
    public EmployeeName? EmployeeName { get; set; }
    public ICollection<EmployeeSkill>? EmployeeSkills { get; set; }

}
