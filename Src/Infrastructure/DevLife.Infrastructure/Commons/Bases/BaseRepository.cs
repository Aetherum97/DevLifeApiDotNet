﻿using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Commons.Bases;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Commons.Bases;

public abstract class BaseRepository<T>(DbContext dbContext) : IBaseRepository<T>
        where T : AuditableBaseEntity
{
    public virtual async Task<List<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(object id)
    {
        return await dbContext.Set<T>().FindAsync(id) ?? throw new InvalidOperationException("Ressources not Found");
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        dbContext.Set<T>().Update(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T> DeleteAsync(T entity)
    {
        dbContext.Set<T>().Remove(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

}
