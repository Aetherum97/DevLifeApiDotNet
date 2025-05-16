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
    public class EmployeeNameService : IEmployeeNameService
    {
        private readonly IEmployeeNameRepository _employeeNameRepository;

        public EmployeeNameService(IEmployeeNameRepository employeeNameRepository)
        {
            _employeeNameRepository = employeeNameRepository;
        }

        public async Task<List<EmployeeName>> GetAllAsync()
        {
            return await _employeeNameRepository.GetAllAsync();
        }
    }
}
