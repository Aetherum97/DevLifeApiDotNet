using DevLife.Application.Modules.Contracts.Interfaces.Repositories;
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
    public sealed class ContractRepository(AppDbContext context) : BaseRepository<Contract>(context), IContractRepository
    {
    }
}
