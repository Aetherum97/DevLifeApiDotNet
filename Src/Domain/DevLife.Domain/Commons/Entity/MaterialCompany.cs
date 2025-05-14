using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Materials;

namespace DevLife.Domain.Commons.Entity;

public class MaterialCompany : AuditableBaseEntity
{
    //public required Employee IdEmployee { get; set; }
    public required Material IdMaterial { get; set; }
}