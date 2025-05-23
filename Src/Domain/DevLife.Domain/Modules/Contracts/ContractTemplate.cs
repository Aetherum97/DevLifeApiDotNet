using DevLife.Domain.Commons.Bases;
namespace DevLife.Domain.Modules.Contracts;

public class ContractTemplate : AuditableBaseEntity
{
    public required Guid TypeId { get; set; }
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public required string Description { get; set; }

    //Relation
    public ContractType? ContractTypes { get; set; }
    public ICollection<Contract>? Contracts { get; set; }
}