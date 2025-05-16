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
        Task<List<Contract>> GetAllAsync();

    }
}
