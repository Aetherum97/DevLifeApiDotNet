using System;
using System.Runtime.InteropServices;
using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Contracts;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Commons.Repositories;

public class CompanyContractEmployeeRepository(AppDbContext context) : BaseRepository<CompanyContractEmployee>(context), ICompanyContractEmployeeRepository
{
    public async Task<CompanyContractEmployee?> GetByContractAndEmployeeAsync(Guid contractId, Guid employeeId)
    {
        return await context.Set<CompanyContractEmployee>()
            .FirstOrDefaultAsync(cce => cce.ContractId == contractId && cce.EmployeeId == employeeId);
    }

    public override async Task<CompanyContractEmployee> CreateAsync(CompanyContractEmployee entity)
    {
        var contract = await context.Set<Contract>()
            .Include(c => c.CompanyContract)
            .FirstOrDefaultAsync(c => c.Id == entity.ContractId) ?? throw new InvalidOperationException($"ContractCompany with ID {entity.ContractId} not found");

        var employee = await context.Set<Employee>()
            .Include(e => e.CompanyEmployee)
            .FirstOrDefaultAsync(c => c.Id == entity.EmployeeId) ?? throw new InvalidOperationException($"ContractCompany with ID {entity.EmployeeId} not found");

        if (employee.CompanyEmployee == null)
        {
            throw new InvalidOperationException($"employee does not belopng to a company");
        }

        if (contract.CompanyContract == null)
        {
            throw new InvalidOperationException($"contract does not belopng to a company");
        }

        if (employee.CompanyEmployee.CompanyId != contract.CompanyContract.CompanyId)
        {

            throw new InvalidOperationException($"Company does not match");
        }

        var assignment = new CompanyContractEmployee
        {
            CompanyId = employee.CompanyEmployee.CompanyId,
            ContractId = contract.CompanyContract.ContractId,
            EmployeeId = employee.CompanyEmployee.EmployeeId
        };

        await context.Set<CompanyContractEmployee>().AddAsync(assignment);
        await context.SaveChangesAsync();
        return assignment;
    }
}
