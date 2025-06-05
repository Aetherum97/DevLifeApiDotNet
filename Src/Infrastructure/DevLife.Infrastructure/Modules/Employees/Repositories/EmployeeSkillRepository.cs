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

public sealed class EmployeeSkillRepository(AppDbContext context) : BaseRepository<EmployeeSkill>(context), IEmployeeSkillRepository
{

    public async Task<List<EmployeeSkill>> GetEmployeeSkillsAsync(IEnumerable<Guid> skillIds)
    {
        var existingSkills = await context.EmployeeSkill
            .Where(es => skillIds.Contains(es.Id))
            .ToListAsync();

        return existingSkills;
    }

}
