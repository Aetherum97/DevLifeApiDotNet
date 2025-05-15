using System;
using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{

}
