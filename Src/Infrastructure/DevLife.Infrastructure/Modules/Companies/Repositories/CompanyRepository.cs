using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;

namespace DevLife.Infrastructure.Modules.Companies.Repositories;

public class CompanyRepository(AppDbContext context) : BaseRepository<Company>(context), ICompanyRepository
{
}

