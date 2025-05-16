using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;



namespace DevLife.Domain.Modules.Materials;

public class Material : AuditableBaseEntity
{
    public required Guid MaterialTemplateId { get; set; }

    // Relation
    public required CompanyMaterial CompanyMaterial{ get; set; }
    public required MaterialTemplate MaterialTemplate { get; set; }
}