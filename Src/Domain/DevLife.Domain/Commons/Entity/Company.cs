using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Players;


namespace DevLife.Domain.Commons.Entity;

public class Company : AuditableBaseEntity
{
    public required string Name { get; set; }
    public required int Experience { get; set; }

    // Relations
    public Player? Player { get; set; }
    public ICollection<Employee>? Employees { get; set; }
    
    public ICollection<MaterialCompany>? MaterialCompany { get; set; }

}
