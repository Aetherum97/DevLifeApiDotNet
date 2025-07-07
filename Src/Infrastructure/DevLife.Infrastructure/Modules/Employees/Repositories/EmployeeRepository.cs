using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Employees.Repositories;

public class EmployeeRepository(AppDbContext context, IReferenceDataCacheService cache) : BaseRepository<Employee>(context), IEmployeeRepository
{
    public override async Task<List<Employee>> GetAllAsync()
    {
        var employees = await context.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.CompanyEmployee)
            .Select(e => new Employee
            {
                Id = e.Id,
                Salary = e.Salary,
                Experience = e.Experience,
                Level = e.Level,
                CFrontEnd = e.CFrontEnd,
                CBackEnd = e.CBackEnd,
                CDevops = e.CDevops,
                CDatabase = e.CDatabase,
                IsAvalaible = e.IsAvalaible,
                EmployeeNameId = e.EmployeeNameId,
                CompanyEmployee = e.CompanyEmployee,
                EmployeeSkills = e.EmployeeSkills.Select(es => new EmployeeSkill { Id = es.Id }).ToList()
            })
            .ToListAsync();

        var allSkillIds = employees
            .SelectMany(e => e.EmployeeSkills)
            .Select(es => es.Id)
            .ToHashSet();

        var skillsFromCache = cache.Get<EmployeeSkill>()
            .Where(es => allSkillIds.Contains(es.Id))
            .ToList();

        var allSkillModificators = cache.Get<EmployeeSkillModificator>();

        foreach (var skill in skillsFromCache)
        {
            var sm = allSkillModificators
                .Where(mod => mod.EmployeeSkills?.Any(es => es.Id == skill.Id) == true)
                .ToList();
            skill.SkillModificators = sm;
        }

        foreach (var employee in employees)
        {
            var employeeName = cache.GetById<EmployeeName>(employee.EmployeeNameId);
            if (employeeName is not null)
                employee.EmployeeName = employeeName;

            var employeeSkillIds = employee.EmployeeSkills.Select(es => es.Id).ToHashSet();
            var employeeSkillsFromCache = skillsFromCache
                .Where(s => employeeSkillIds.Contains(s.Id))
                .ToList();

            employee.EmployeeSkills = employeeSkillsFromCache;
        }

        return employees;
    }

    public override async Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = await context.Set<Employee>()
            .AsNoTracking()
            .Include(e => e.CompanyEmployee)
            .Select(e => new Employee
            {
                Id = e.Id,
                Salary = e.Salary,
                Experience = e.Experience,
                Level = e.Level,
                CFrontEnd = e.CFrontEnd,
                CBackEnd = e.CBackEnd,
                CDevops = e.CDevops,
                CDatabase = e.CDatabase,
                IsAvalaible = e.IsAvalaible,
                EmployeeNameId = e.EmployeeNameId,
                CompanyEmployee = e.CompanyEmployee,
                EmployeeSkills = e.EmployeeSkills.Select(es => new EmployeeSkill { Id = es.Id }).ToList()
            })
            .FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new InvalidOperationException("Ressource not Found");

        var employeeName = cache.GetById<EmployeeName>(employee.EmployeeNameId);
        if (employeeName is not null)
            employee.EmployeeName = employeeName;

        var skillIds = employee.EmployeeSkills.Select(es => es.Id).ToHashSet();
        var skillsFromCache = cache.Get<EmployeeSkill>()
            .Where(es => skillIds.Contains(es.Id))
            .ToList();

        var allSkillModificators = cache.Get<EmployeeSkillModificator>();

        foreach (var skill in skillsFromCache)
        {
            var sm = allSkillModificators
                .Where(mod => mod.EmployeeSkills?.Any(es => es.Id == skill.Id) == true)
                .ToList();

            skill.SkillModificators = sm;
        }
        
        employee.EmployeeSkills = skillsFromCache;

        return employee;
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
