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
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;

        public EmployeeSkillService(IEmployeeSkillRepository employeeSkillRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
        }

        public async Task<List<EmployeeSkill>> GetAllAsync()
        {
            return await _employeeSkillRepository.GetAllAsync();
        }
    }
}
