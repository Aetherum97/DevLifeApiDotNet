using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Commons.Entity;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;

namespace DevLife.Infrastructure.Commons.Repositories;

public class EmployeeRepository(AppDbContext context) : BaseRepository<Employee>(context), IEmployeeRepository
{
}
