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
    public class ContractTemplateService : IContractTemplateService
    {
        private readonly IContractTemplateRepository _contractTemplateRepository;

        public ContractTemplateService(IContractTemplateRepository contractTemplateRepository)
        {
            _contractTemplateRepository = contractTemplateRepository;
        }

        public async Task<List<ContractTemplate>> GetAllAsync()
        {
            return await _contractTemplateRepository.GetAllAsync();
        }
    }
}
