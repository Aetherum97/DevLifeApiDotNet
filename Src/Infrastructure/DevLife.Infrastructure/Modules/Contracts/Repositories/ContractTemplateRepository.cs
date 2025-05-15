using DevLife.Application.Modules.Contracts.Interfaces;
using DevLife.Domain.Modules.Contracts;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Modules.Contracts.Repositories
{
    public sealed class ContractTemplateRepository(AppDbContext context) : BaseRepository<ContractTemplate>(context), IContractTemplateRepository
    {
    }
}
