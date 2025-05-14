using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Contracts;

namespace DevLife.Domain.Commons.Entity;

public class CompanyContract : AuditableBaseEntity
{
    public required Guid IdCompany { get; set; }
    public required Guid IdContract { get; set; }
    public required DateTime Deadline { get; set; }
    public required DateTime StartDate { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsCompleted { get; set; }
    public int? Progress { get; set; }
    public required int Reward { get; set; }

    //Relation
    public Company? Company { get; set; }
    public Contract? Contract { get; set; }
    public ICollection<Employee>? Employees { get; set; }

}