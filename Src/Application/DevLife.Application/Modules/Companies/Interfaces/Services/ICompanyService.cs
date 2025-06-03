using DevLife.Application.Modules.Companies.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Companies.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetAllAsync();

    }
}
