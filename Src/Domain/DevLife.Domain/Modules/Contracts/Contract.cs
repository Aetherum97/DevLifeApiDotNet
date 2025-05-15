using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Companies;

namespace DevLife.Domain.Modules.Contracts.Entity;

public class Contract : AuditableBaseEntity
{
    public required Guid IdCompany { get; set; }
    public required Guid IdContractTemplate { get; set; }
    public required DateTime Deadline { get; set; }
    public required DateTime StartDate { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsCompleted { get; set; }
    public int? Progress { get; set; }
    public required int Reward { get; set; }

    //Relation
    public ICollection<CompanyContractEmployee>? CompanyContractEmployees { get; set; }
    public ContractTemplate? ContractTemplate { get; set; }
    

}