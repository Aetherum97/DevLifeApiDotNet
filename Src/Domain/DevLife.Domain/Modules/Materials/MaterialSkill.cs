using DevLife.Domain.Commons.Bases;

namespace DevLife.Domain.Modules.Materials;

public class MaterialSkill : AuditableBaseEntity
{
    public required string Name { get; set; }
    public required int Modificator { get; set; }

    // Relation
    public ICollection<Material>? Materials { get; set; }
}