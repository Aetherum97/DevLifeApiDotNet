using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Contracts.Entity;
using DevLife.Domain.Modules.Employees;
using DevLife.Domain.Modules.Materials.Entity;

namespace DevLife.Domain.Commons.Entity;

public class CompanyMaterialEmployee : BaseEntity
{
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public Guid MaterialId { get; set; }
    public Material? Material { get; set; }
}
