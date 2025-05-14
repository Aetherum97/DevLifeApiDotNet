using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;

namespace DevLife.Domain.Modules.Companies;

public class Player : AuditableBaseEntity
{
    public required string PlayerName { get; set; }
    public required bool IsTutorialFinished { get; set; }

    // Relation
    public required Guid UserId { get; set; }
    public required Company Compagny { get; set; }
}
