using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Application.Modules.Companies.Interfaces.Services;
using DevLife.Domain.Modules.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Companies.Services
{
    public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
    {
        public async Task<List<Company>> GetAllAsync()
        {
            return await companyRepository.GetAllAsync();
        }
    }
}
