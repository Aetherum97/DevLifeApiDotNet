using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Materials;

namespace DevLife.Domain.Commons.Entity;

public class MaterialCompany : AuditableBaseEntity
{
    public required Guid IdEmployee { get; set; }
    public required Guid IdCompany { get; set; }
    public required Guid IdMaterial { get; set; }

    // Relation
    public Company? Company { get; set; }
    public Employee? Employee { get; set; }
    public Material? Material { get; set; }
}