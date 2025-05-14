using DevLife.Domain.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Commons.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : AuditableBaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
