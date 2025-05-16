using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;



namespace DevLife.Domain.Modules.Materials;

public class Material : AuditableBaseEntity
{
    public required Guid EmployeeId { get; set; }
    public required Guid CompanyId { get; set; }
    public required Guid MaterialTemplateId { get; set; }

    // Relation
    public ICollection<CompanyMaterialEmployee>? CompanyMaterialEmployees { get; set; }
    public MaterialTemplate? MaterialTemplate { get; set; }
}