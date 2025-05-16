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
        public async Task<List<ContractType>> GetAllAsync()
        {
            return await contractTypeRepository.GetAllAsync();
        }
    }
}
