using DevLife.Application.Modules.Companies.DTOs;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Application.Modules.Companies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Companies.Services
{
    public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
    {
        public async Task<List<CompanyDto>> GetAllAsync()
        {
            var result = await companyRepository.GetAllAsync();
            var response = result.Select(item => new CompanyDto(item)).ToList() ?? [];
            return response;
        }

        public async Task<CompanyDto?> GetByIdAsync(Guid id)
        {
            var company = await companyRepository.GetByIdAsync(id);
            if (company == null)
                return null;

            return new CompanyDto(company);
        }
    }
}
