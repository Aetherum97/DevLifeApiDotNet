using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Companies.Repositories;

public class CompanyRepository(AppDbContext context) : BaseRepository<Company>(context), ICompanyRepository
{
    public override async Task<List<Company>> GetAllAsync()
    {
        return await context.Set<Company>()
                .AsNoTracking()
                .Include(c => c.Player)
                .Include(c => c.CompanyEmployees)
                    .ThenInclude(ce => ce.Employee)
                .Include(c => c.CompanyContracts)
                    .ThenInclude(cc => cc.Contract)
                        .ThenInclude(contract => contract!.ContractTemplate)
                            .ThenInclude(ct => ct!.ContractTypes)
                .Include(c => c.CompanyMaterials)
                    .ThenInclude(cm => cm.Material)
                        .ThenInclude(material => material!.MaterialTemplate)
                            .ThenInclude(mt => mt!.MaterialSkill)
                .ToListAsync();
    }

    public override async Task<Company> GetByIdAsync(Guid id)
    {
        var company = await context.Set<Company>()
            .AsNoTracking()
            .Include(c => c.Player)
            .Include(c => c.CompanyEmployees)
                .ThenInclude(ce => ce.Employee)
            .Include(c => c.CompanyContracts)
                .ThenInclude(cc => cc.Contract)
                    .ThenInclude(contract => contract!.ContractTemplate)
                        .ThenInclude(ct => ct!.ContractTypes)
            .Include(c => c.CompanyMaterials)
                .ThenInclude(cm => cm.Material)
                    .ThenInclude(material => material!.MaterialTemplate)
                        .ThenInclude(mt => mt!.MaterialSkill)
            .FirstOrDefaultAsync(c => c.Id == id);
        return company ?? throw new InvalidOperationException("Ressources not Found");
    }
}

