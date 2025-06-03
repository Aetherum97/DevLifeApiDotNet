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
    public class ContractTemplateService(IContractTemplateRepository contractTemplateRepository) : IContractTemplateService
    {
        public async Task<List<ContractTemplateDto>> GetAllAsync()
        {
            var result = await contractTemplateRepository.GetAllAsync();

            var response = (result ?? []).Select(item => new ContractTemplateDto(item)).ToList();
            return response;
        }
    }
}
