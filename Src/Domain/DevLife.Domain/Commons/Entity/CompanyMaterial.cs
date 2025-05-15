using System;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Materials;

namespace DevLife.Domain.Commons.Entity;

public class CompanyMaterial
{
    public Guid MaterialId { get; set; }
    public Material? Material { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public ICollection<CompanyMaterialEmployee>? AssignedMaterial { get; set; }
}
