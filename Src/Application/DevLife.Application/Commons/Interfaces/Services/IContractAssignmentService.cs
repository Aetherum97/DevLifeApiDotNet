using System;
using DevLife.Application.Commons.DTOs.Requests;
using DevLife.Application.Commons.DTOs.Responses;

namespace DevLife.Application.Commons.Interfaces.Services;

public interface IContractAssignmentService
{
    Task<ContractAssignmentResponse> ContractAsignment(ContractAssignmentRequest request);
}
