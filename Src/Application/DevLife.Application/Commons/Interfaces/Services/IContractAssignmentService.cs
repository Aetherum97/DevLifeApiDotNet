using System;
using DevLife.Application.Commons.DTOs;
using DevLife.Application.Commons.DTOs.Requests;
using DevLife.Application.Commons.DTOs.Responses;

namespace DevLife.Application.Commons.Interfaces.Services;

public interface IContractAssignmentService
{
    Task<CompanyContractEmployeeDto> ContractGetAsignment(ContractAssignmentRequest request);
    Task<List<CompanyContractEmployeeDto>> ContractGetAllAsignment(Guid request);
    Task<ContractAssignmentResponse> ContractCreateAsignment(ContractAssignmentRequest request);
    Task<CompanyContractEmployeeDto> ContractUpdateAsignment(ContractAssignmentUpdateRequest request);
    Task<ContractAssignmentResponse> ContractDeleteAsignment(ContractAssignmentRequest request);

}
