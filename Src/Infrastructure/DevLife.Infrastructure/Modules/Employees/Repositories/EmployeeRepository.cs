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

    public override async Task<Employee> UpdateAsync(Employee entity)
    {
        var existingEmployee = await context.Set<Employee>()
            .Include(e => e.EmployeeSkills)
            .FirstOrDefaultAsync(e => e.Id == entity.Id) ?? throw new InvalidOperationException($"Employee with ID {entity.Id} not found");

        context.Entry(existingEmployee).CurrentValues.SetValues(entity);


        var curentSkillIds = existingEmployee.EmployeeSkills.Select(es => es.Id).ToHashSet();
        var newskillIds = entity.EmployeeSkills.Select(es => es.Id).ToHashSet();

        if (curentSkillIds.SetEquals(newskillIds))
        {
            await context.SaveChangesAsync();
            return await GetByIdAsync(existingEmployee.Id);
        }

        RemoveOldSkills();
        await AddNewSkillsAsync();

        await context.SaveChangesAsync();
        return await GetByIdAsync(existingEmployee.Id);

        void RemoveOldSkills()
        {
            var toRemove = curentSkillIds.Except(newskillIds).ToList();

            var skillsToRemove = existingEmployee.EmployeeSkills.Where(es => toRemove.Contains(es.Id)).ToList();
            foreach (var skill in skillsToRemove)
            {
                existingEmployee.EmployeeSkills.Remove(skill);
            }

        }

        async Task AddNewSkillsAsync()
        {
            var toAdd = newskillIds.Except(curentSkillIds).ToList();

            var newSkills = await context.Set<EmployeeSkill>()
                .Where(s => toAdd.Contains(s.Id))
                .ToListAsync();

            foreach (var skill in newSkills)
            {
                existingEmployee.EmployeeSkills.Add(skill);
            }
        }
    }
}
