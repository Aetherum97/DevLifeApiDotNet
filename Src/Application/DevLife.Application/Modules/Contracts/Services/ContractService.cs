using DevLife.Application.Modules.Contracts.DTOs;
using DevLife.Application.Modules.Contracts.Interfaces.Repositories;
using DevLife.Application.Modules.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Contracts.Services;

public class ContractService(IContractRepository contractRepository) : IContractService
{
    public async Task<List<ContractDto>> GetAllAsync()
    {
        var result = await contractRepository.GetAllAsync();

        var response = (result ?? []).Select(item => new ContractDto(item)).ToList();
        return response;
    }
}

