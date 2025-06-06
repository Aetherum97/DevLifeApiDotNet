using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Employees.Repositories;

public sealed class EmployeeSkillRepository(AppDbContext context, IReferenceDataCacheService cache)
    : BaseRepository<EmployeeSkill>(context), IEmployeeSkillRepository
{
    public async Task<List<EmployeeSkill>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        var idList = ids.Distinct().ToList();

        var cachedItems = cache.Get<EmployeeSkill>().Where(e => idList.Contains(e.Id)).ToList();

        var missingIds = idList.Except(cachedItems.Select(e => e.Id)).ToList();

        if (missingIds.Count != 0)
        {
            var fromDb = await context.Set<EmployeeSkill>().Where(e => missingIds.Contains(e.Id)).ToListAsync();
            cachedItems.AddRange(fromDb);

            var stillMissing = missingIds.Except(fromDb.Select(e => e.Id)).ToList();
            if (stillMissing.Count != 0)
                throw new KeyNotFoundException($"Entity {typeof(EmployeeSkill).Name} not found for ID(s): {string.Join(", ", stillMissing)}");
        }

        AttachEntities(cachedItems);

        return cachedItems;
    }

    public override async Task<EmployeeSkill> GetByIdAsync(Guid id)
    {
        var cached = cache.GetById<EmployeeSkill>(id);
        if (cached != null)
        {
            AttachEntity(cached);
            return cached;
        }

        var fromDb = await context.Set<EmployeeSkill>().FirstOrDefaultAsync(e => e.Id == id);
        if (fromDb != null)
        {
            AttachEntity(fromDb);
            return fromDb;
        }

        throw new KeyNotFoundException($"Entity {typeof(EmployeeSkill).Name} not found for ID: {id}");
    }

    public override async Task<List<EmployeeSkill>> GetAllAsync()
    {
        var cached = cache.Get<EmployeeSkill>().ToList();
        if (cached.Count != 0)
        {
            AttachEntities(cached);
            return cached;
        }

        var fromDb = await context.Set<EmployeeSkill>().ToListAsync();
        AttachEntities(fromDb);
        return fromDb;
    }

    public EmployeeSkill GetTrackedEntityById(Guid id)
    {
        var trackedEntity = context.Set<EmployeeSkill>().Local.FirstOrDefault(e => e.Id == id);
        return trackedEntity!;
    }


    private void AttachEntity(EmployeeSkill entity)
    {
        if (context.Entry(entity).State == EntityState.Detached)
            context.Attach(entity);
    }

    private void AttachEntities(IEnumerable<EmployeeSkill> entities)
    {
        foreach (var entity in entities)
        {
            var trackedEntity = context.Set<EmployeeSkill>().Local.FirstOrDefault(e => e.Id == entity.Id);
            if (trackedEntity == null)
            {
                context.Attach(entity);
            }
            else
            {
                context.Entry(trackedEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}
