using System;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Employees.Seeds.Default;

public static class DefaultEmployeeSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.Employee.AnyAsync())
        {
            var employeeName = await context.EmployeeName.FirstOrDefaultAsync();
            var skills = await context.EmployeeSkill.Take(2).ToListAsync();
            var company = await context.Company.FirstOrDefaultAsync();

            if (employeeName == null || skills.Count == 0) return;

            var employee = new Employee
            {
                EmployeeNameId = employeeName.Id,
                Salary = 60000,
                Experience = 3,
                Level = 2,
                CFrontEnd = 7,
                CBackEnd = 8,
                CDevops = 6,
                CDatabase = 7,
                IsAvalaible = true,
                EmployeeSkills = skills,
            };

            var companyEmployee = new CompanyEmployee
            {
                CompanyId = company!.Id,
                Employee = employee
            };

            context.Employee.Add(employee);
            context.CompanyEmployee.Add(companyEmployee);
            await context.SaveChangesAsync();
        }
    }
}
