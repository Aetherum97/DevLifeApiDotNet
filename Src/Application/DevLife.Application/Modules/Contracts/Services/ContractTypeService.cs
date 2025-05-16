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
    public class ContractTypeService : IContractTypeService
    {
        private readonly IContractTypeRepository _contractTypeRepository;

        public ContractTypeService(IContractTypeRepository contractTypeRepository)
        {
            _contractTypeRepository = contractTypeRepository;
        }

        public async Task<List<ContractType>> GetAllAsync()
        {
            return await _contractTypeRepository.GetAllAsync();
        }
    }
}
