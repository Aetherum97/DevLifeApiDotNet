using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Contracts;

namespace DevLife.Domain.Commons.Entity;

public class CompanyContract : AuditableBaseEntity
{
    //public required Company IdCompany { get; set; }
    public required Contract IdContract { get; set; }
    public required DateTime deadline { get; set; }
    public required DateTime startDate { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsCompleted { get; set; }
    public int? Progress { get; set; }
    public required int Reward { get; set; }
}