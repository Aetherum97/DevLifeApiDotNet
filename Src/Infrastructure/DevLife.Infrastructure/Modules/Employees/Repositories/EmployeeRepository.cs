using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Employees.Repositories;

public class EmployeeRepository(AppDbContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
    public override async Task<List<Employee>> GetAllAsync()
    {
        return await context.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.EmployeeName)
            .Include(e => e.EmployeeSkills)
                .ThenInclude(es => es.SkillModificators)
            .Include(e => e.CompanyEmployee)
            .ToListAsync();
    }

    public override async Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = await context.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.EmployeeName)
            .Include(e => e.EmployeeSkills)
                .ThenInclude(es => es.SkillModificators)
            .Include(e => e.CompanyEmployee)
            .FirstOrDefaultAsync(e => e.Id == id);

        return employee ?? throw new InvalidOperationException("Ressources not Found");
    }
}
