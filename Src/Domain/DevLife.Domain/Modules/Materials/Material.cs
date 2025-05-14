using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;

namespace DevLife.Domain.Modules.Materials;

public class Material : AuditableBaseEntity
{
    public required Guid IdMaterialSkill { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }

    //Relation
    public MaterialSkill? MaterialSkill { get; set; }

    public ICollection<MaterialCompany>? MaterialCompany { get; set; }
}