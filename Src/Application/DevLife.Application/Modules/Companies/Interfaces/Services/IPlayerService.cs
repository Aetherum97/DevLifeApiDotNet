using DevLife.Domain.Modules.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Companies.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<List<Player>> GetAllAsync();

    }
}
