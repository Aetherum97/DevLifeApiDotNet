using System;

namespace DevLife.Application.Commons.Interfaces.Services.Accessors;

public interface IUserCompanyAccessor
{
    Task<Guid> GetCompanyIdForUserAsync(Guid userId);
}
