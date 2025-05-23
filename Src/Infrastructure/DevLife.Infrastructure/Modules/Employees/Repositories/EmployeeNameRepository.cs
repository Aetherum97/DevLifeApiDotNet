﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;

namespace DevLife.Infrastructure.Modules.Employees.Repositories;

public sealed class EmployeeNameRepository(AppDbContext context) : BaseRepository<EmployeeName>(context), IEmployeeNameRepository
{
}


