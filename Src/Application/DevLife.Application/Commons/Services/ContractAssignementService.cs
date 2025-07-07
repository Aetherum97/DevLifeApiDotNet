using DevLife.Application.Commons.DTOs;
using DevLife.Application.Commons.DTOs.Requests;
using DevLife.Application.Commons.DTOs.Responses;
using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Modules.Contracts.Interfaces.Repositories;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Domain.Commons.Entity;

namespace DevLife.Application.Commons.Services;

public class ContractAssignementService(
    ICompanyContractEmployeeRepository companyContractEmployeeRepository,
    IContractRepository contractRepository,
    IEmployeeRepository employeeRepository
    ) : IContractAssignmentService
{

    public async Task<List<CompanyContractEmployeeDto>> ContractGetAllAsignment(Guid request)
    {
        var result = await companyContractEmployeeRepository.GetAllContractAssignementAsync(request) ?? throw new InvalidOperationException($"contract assignement does not exist");
        var response = (result ?? []).Select(item => new CompanyContractEmployeeDto(item)).ToList();

        return response;
    }


    public async Task<CompanyContractEmployeeDto> ContractGetAsignment(ContractAssignmentRequest request)
    {
        var result = await companyContractEmployeeRepository.GetByContractAndEmployeeAsync(request.ContractId, request.EmployeId) ?? throw new InvalidOperationException($"contract assignement does not exist");

        if (result.CompanyId != request.CompanyId)
        {
            throw new InvalidOperationException($"contract assignement does not belong to the company");
        }

        return new CompanyContractEmployeeDto(result);
    }

    public async Task<ContractAssignmentResponse> ContractCreateAsignment(ContractAssignmentRequest request)
    {
        var contractAsignment = new CompanyContractEmployee
        {
            CompanyId = request.CompanyId,
            EmployeeId = request.EmployeId,
            ContractId = request.ContractId,
        };

        var result = await companyContractEmployeeRepository.CreateAsync(contractAsignment);

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

    public async Task<CompanyContractEmployeeDto> ContractUpdateAsignment(ContractAssignmentUpdateRequest request)
    {
        var contractAsignment = await companyContractEmployeeRepository.GetByContractAndEmployeeAsync(request.PreviousContractId, request.PreviousEmployeId) ?? throw new InvalidOperationException($"contract assignement does not exist");

        if (request.NewContractId != Guid.Empty)
        {
            var contract = await contractRepository.GetByIdAsync(request.NewContractId)
                ?? throw new InvalidOperationException($"Contract with ID {request.NewContractId} does not exist");

            contractAsignment.ContractId = contract.Id;
        }

        if (request.NewEmployeId != Guid.Empty)
        {
            var employee = await employeeRepository.GetByIdAsync(request.NewEmployeId)
                ?? throw new InvalidOperationException($"Employee with ID {request.NewEmployeId} does not exist");

            contractAsignment.EmployeeId = employee.Id;
        }

        var result = await companyContractEmployeeRepository.UpdateAsync(contractAsignment);

        return new CompanyContractEmployeeDto(result);
    }

    public async Task<ContractAssignmentResponse> ContractDeleteAsignment(ContractAssignmentRequest request)
    {
        var contractAsignment = await companyContractEmployeeRepository.GetByContractAndEmployeeAsync(request.ContractId, request.EmployeId) ?? throw new InvalidOperationException($"contract assignement does not exist");

        if (contractAsignment.CompanyId != request.CompanyId)
        {
            throw new InvalidOperationException($"contract assignement does not belong to the company");
        }

        var result = await companyContractEmployeeRepository.DeleteAsync(contractAsignment);

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
