using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Application.Modules.Employees.Interfaces.Services;
using DevLife.Domain.Modules.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Employees.Services
{
    public class EmployeeSkillModificatorService(IEmployeeSkillModificatorRepository employeeSkillModificatorRepository) : IEmployeeSkillModificatorService
    {
        public async Task<List<EmployeeSkillModificator>> GetAllAsync()
        {
            return await employeeSkillModificatorRepository.GetAllAsync();
        }
    }
}
