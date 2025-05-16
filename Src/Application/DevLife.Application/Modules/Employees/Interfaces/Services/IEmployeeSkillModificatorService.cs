using DevLife.Domain.Modules.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Employees.Interfaces.Services
{
    public interface IEmployeeSkillModificatorService
    {
        Task<List<EmployeeSkillModificator>> GetAllAsync();

    }
}
