using System;
using DevLife.Application.Commons.DTOs.Requests;
using DevLife.Application.Commons.DTOs.Responses;
using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Application.Commons.Interfaces.Services;

using DevLife.Domain.Commons.Entity;

namespace DevLife.Application.Commons.Services;

public class ContractAssignementService(
    ICompanyContractEmployeeRepository companyContractEmployeeRepository
    ) : IContractAssignmentService
{
    public async Task<ContractAssignmentResponse> ContractAsignment(ContractAssignmentRequest request)
    {




        var contractAsignment = new CompanyContractEmployee
        {
            CompanyId = request.ContractId,
            EmployeeId = request.EmployeId,
            ContractId = request.ContractId,
        };

        var result = await companyContractEmployeeRepository.AddAsync(contractAsignment);

        if (result != null)
        {

            return new ContractAssignmentResponse
            {
                Success = true
            };
        }

        return new ContractAssignmentResponse
        {
            Success = false
        };
    }
}
