using System;
using DevLife.Domain.Commons.Bases;

namespace DevLife.Application.Commons.Interfaces.Services;

public interface IReferenceDataCacheService
{
    Task InitializeAsync();
    IEnumerable<T> Get<T>() where T : AuditableBaseEntity;
    T? GetById<T>(Guid id) where T : AuditableBaseEntity;

}
