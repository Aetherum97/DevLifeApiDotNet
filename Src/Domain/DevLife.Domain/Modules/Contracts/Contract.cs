using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;


namespace DevLife.Domain.Modules.Contracts;

public class Contract : AuditableBaseEntity
{
    public required Guid IdContractTemplate { get; set; }
    public required DateTime Deadline { get; set; }
    public required DateTime StartDate { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsCompleted { get; set; }
    public int? Progress { get; set; }
    public required int Reward { get; set; }

    //Relation
    public required CompanyContract CompanyContract { get; set; }
    public required ContractTemplate ContractTemplate { get; set; }
    

}