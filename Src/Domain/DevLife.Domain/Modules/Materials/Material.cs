using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;



namespace DevLife.Domain.Modules.Materials;

public class Material : AuditableBaseEntity
{
    public Guid? MaterialTemplateId { get; set; }

    // Relation
    public  CompanyMaterial? CompanyMaterial{ get; set; }
    public  MaterialTemplate? MaterialTemplate { get; set; }
}