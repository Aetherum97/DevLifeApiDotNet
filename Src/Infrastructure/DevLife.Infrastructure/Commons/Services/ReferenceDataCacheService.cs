using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Contracts;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Commons.Interfaces;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevLife.Infrastructure.Commons.Services;

public class ReferenceDataCacheService(IServiceProvider serviceProvider) : IReferenceDataCacheService
{
    private readonly Dictionary<Type, object> _cache = [];
    public async Task InitializeAsync()
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await LoadReferrenceData<ContractTemplate>(context);
        await LoadReferrenceData<ContractType>(context);

        await LoadReferrenceData<EmployeeName>(context);
        await LoadReferrenceData<EmployeeSkillModificator>(context);
        await LoadReferrenceData<EmployeeSkill>(context);

    }

    private async Task LoadReferrenceData<T>(AppDbContext context) where T : AuditableBaseEntity
    {
        using var scope = serviceProvider.CreateScope();
        var includeService = scope.ServiceProvider.GetService<IReferenceInclude<T>>();

        IQueryable<T> query = includeService is not null
            ? includeService.ApplyIncludes(context)
            : context.Set<T>();

        var data = await query.ToListAsync();
        _cache[typeof(T)] = data;
    }

    public IEnumerable<T> Get<T>() where T : AuditableBaseEntity
    {
        if (_cache.TryGetValue(typeof(T), out var data))
        {
            return (List<T>)data;
        }

        return [];
    }

    public T? GetById<T>(Guid id) where T : AuditableBaseEntity
    {
        return Get<T>().FirstOrDefault(e => e.Id == id);
    }
}

public class EmployeeSkillInclude : IReferenceInclude<EmployeeSkill>
{
    public IQueryable<EmployeeSkill> ApplyIncludes(AppDbContext context)
    {
        return context.Set<EmployeeSkill>()
            .Include(s => s.SkillModificators);
    }
}

public class EmployeeSkillModificatorInclude : IReferenceInclude<EmployeeSkillModificator>
{
    public IQueryable<EmployeeSkillModificator> ApplyIncludes(AppDbContext context)
    {
        return context.Set<EmployeeSkillModificator>()
            .Include(m => m.EmployeeSkills);
    }
}