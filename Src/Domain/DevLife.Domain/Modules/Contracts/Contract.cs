using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;


namespace DevLife.Domain.Modules.Contracts;

public class Contract : AuditableBaseEntity
{
    public Guid ContractTemplateId { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsAccepted { get; set; }
    public bool IsCompleted { get; set; }
    public int Progress { get; set; }
    public required int Reward { get; set; }

    //Relation
    public CompanyContract? CompanyContract { get; set; }
    public ContractTemplate? ContractTemplate { get; set; }
}