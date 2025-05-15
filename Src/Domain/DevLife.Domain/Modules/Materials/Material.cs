using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;



namespace DevLife.Domain.Modules.Materials.Entity;

public class Material : AuditableBaseEntity
{
    public required Guid IdEmployee { get; set; }
    public required Guid IdCompany { get; set; }
    public required Guid IdMaterial { get; set; }

    // Relation
    public ICollection<CompanyMaterialEmployee>? CompanyMaterialEmployees { get; set; }
    public MaterialType? MaterialType { get; set; }
}