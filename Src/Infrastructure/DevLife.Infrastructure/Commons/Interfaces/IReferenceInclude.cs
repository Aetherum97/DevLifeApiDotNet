using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;

namespace DevLife.Infrastructure.Commons.Interfaces;

public interface IReferenceInclude<T> where T : AuditableBaseEntity
{
    IQueryable<T> ApplyIncludes(AppDbContext context);
}