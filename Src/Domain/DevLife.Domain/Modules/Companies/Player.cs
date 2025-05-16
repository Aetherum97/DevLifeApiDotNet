using System;
using DevLife.Domain.Commons.Bases;


namespace DevLife.Domain.Modules.Companies;

public class Player : AuditableBaseEntity
{
    public required string PlayerName { get; set; }
    public required bool IsTutorialFinished { get; set; }
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }

    // Relation
    public required Company Compagny { get; set; }

}
