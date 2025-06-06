using System;
using DevLife.Domain.Commons.Entity;

namespace DevLife.Application.Commons.Interfaces.Repositories;

public interface ICompanyContractEmployeeRepository : IBaseRepository<CompanyContractEmployee>
{
    Task<CompanyContractEmployee?> GetByContractAndEmployeeAsync(Guid contractId, Guid employeeId);
    
}
