using DevLife.Domain.Commons.Bases;

namespace DevLife.Domain.Modules.Contracts;

public class ContractType : AuditableBaseEntity
{
    public required string Name { get; set; } = string.Empty;

    //Relation
    public ICollection<ContractTemplate>? Contracts { get; set; }
}