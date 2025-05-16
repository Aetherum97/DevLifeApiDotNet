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
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<List<Contract>> GetAllAsync()
        {
            return await _contractRepository.GetAllAsync();
        }
    }
}
