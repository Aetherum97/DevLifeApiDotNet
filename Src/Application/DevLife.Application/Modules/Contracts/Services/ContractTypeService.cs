using DevLife.Application.Modules.Contracts.DTOs;
using DevLife.Application.Modules.Contracts.Interfaces.Repositories;
using DevLife.Application.Modules.Contracts.Interfaces.Services;
using DevLife.Domain.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Contracts.Services
{
    public class ContractTypeService(IContractTypeRepository contractTypeRepository) : IContractTypeService
    {
        public async Task<List<ContractTypeDto>> GetAllAsync()
        {
            var result = await contractTypeRepository.GetAllAsync();

            var response = (result ?? []).Select(item => new ContractTypeDto(item)).ToList();
            return response;
        }
    }
}
