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
    public class EmployeeSkillModificatorService : IEmployeeSkillModificatorService
    {
        private readonly IEmployeeSkillModificatorRepository _employeeSkillModificatorRepository;

        public EmployeeSkillModificatorService(IEmployeeSkillModificatorRepository employeeSkillModificatorRepository)
        {
            _employeeSkillModificatorRepository = employeeSkillModificatorRepository;
        }

        public async Task<List<EmployeeSkillModificator>> GetAllAsync()
        {
            return await _employeeSkillModificatorRepository.GetAllAsync();
        }
    }
}
