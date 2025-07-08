using System;
using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Task<List<Employee>> GetAllAsync(Guid companyId);
}
