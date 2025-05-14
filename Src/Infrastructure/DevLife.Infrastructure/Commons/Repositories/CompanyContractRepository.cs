using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Commons.Entity;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Commons.Repositories
{
    public sealed class CompanyContractRepository(AppDbContext context) : BaseRepository<CompanyContract>(context), ICompanyContractRepository
    {
    }
}
