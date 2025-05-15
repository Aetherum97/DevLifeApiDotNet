using System;
using DevLife.Domain.Commons.Bases;

namespace DevLife.Domain.Commons.Entity;

public class CompanyMaterialEmployee : BaseEntity
{
    public Guid CompanyId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid MaterialId { get; set; }

    public CompanyMaterial? CompanyMaterial { get; set; }
    public CompanyEmployee? CompanyEmployee { get; set; }
   
}
