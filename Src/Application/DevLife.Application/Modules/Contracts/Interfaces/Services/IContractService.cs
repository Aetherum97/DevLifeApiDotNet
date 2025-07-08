using DevLife.Application.Modules.Contracts.DTOs;
using DevLife.Application.Modules.Contracts.DTOs.Requests;
using DevLife.Domain.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Contracts.Interfaces.Services
{
    public interface IContractService
    {
        Task<List<ContractDto>> GetAllByCompanyIdAsync();
        Task<ContractDto> GetByIdAsync(Guid id);
        Task<ContractDto> CreateAsync(ContractCreateRequest request);
        Task<ContractDto> UpdateAsync(ContractUpdateRequest request);
        Task<ContractDto> DeleteAsync(ContractDeleteRequest request);
    }
}
