using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;



namespace DevLife.Domain.Modules.Materials;

public class Material : AuditableBaseEntity
{
    public required Guid IdEmployee { get; set; }
    public required Guid IdCompany { get; set; }
    public required Guid IdMaterialTemplate { get; set; }

    // Relation
    public ICollection<CompanyMaterialEmployee>? CompanyMaterialEmployees { get; set; }
    public MaterialTemplate? MaterialTemplate { get; set; }
}