using System;

namespace DevLife.Application.Commons.Interfaces.Services;

public interface IUserCompanyAccessor
{
    Task<Guid> GetCompanyIdForUserAsync(Guid userId);
}
