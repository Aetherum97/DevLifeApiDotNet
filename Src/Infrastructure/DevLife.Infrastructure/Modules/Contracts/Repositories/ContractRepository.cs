using DevLife.Application.Modules.Contracts.Interfaces.Repositories;
using DevLife.Domain.Modules.Contracts;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Modules.Contracts.Repositories;

public sealed class ContractRepository(AppDbContext context) : BaseRepository<Contract>(context), IContractRepository
{

    public async Task<List<Contract>> GetAllByCompanyIdAsync(Guid companyId)
    {
        return await context.Set<Contract>()
            .AsNoTracking()
            .Include(c => c.ContractTemplate)
                .ThenInclude(ct => ct!.ContractTypes)
            .Include(c => c.CompanyContract)
            .Where(c => c.CompanyContract != null && c.CompanyContract.CompanyId == companyId)
            .ToListAsync();

    }

    public override async Task<Contract> GetByIdAsync(Guid id)
    {
        var contract = await context.Set<Contract>()
            .AsNoTracking()
            .Include(c => c.ContractTemplate)
                .ThenInclude(ct => ct!.ContractTypes)
            .Include(c => c.CompanyContract)
             .FirstOrDefaultAsync(c => c.Id == id);

        return contract ?? throw new InvalidOperationException("Ressource not Found");
    }

}

