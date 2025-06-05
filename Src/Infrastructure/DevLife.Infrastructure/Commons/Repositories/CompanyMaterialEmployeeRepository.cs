using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Commons.Entity;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Commons.Repositories
{
    public class CompanyMaterialEmployeeRepository(AppDbContext context) : BaseRepository<CompanyMaterialEmployee>(context), ICompanyMaterialEmployeeRepository
    {
        public async Task<bool> ToggleAssignmentAsync(Guid companyId, Guid materialId, Guid employeeId)
        {
            var existing = await context.CompanyMaterialEmployee
                .FirstOrDefaultAsync(cme =>
                    cme.CompanyId == companyId &&
                    cme.MaterialId == materialId &&
                    cme.EmployeeId == employeeId);

            if (existing != null)
            {
                context.CompanyMaterialEmployee.Remove(existing);

                await context.SaveChangesAsync();

                return false;
            }
            else
            {
                var toAdd = new CompanyMaterialEmployee
                {
                    CompanyId = companyId,
                    MaterialId = materialId,
                    EmployeeId = employeeId
                };
                await context.CompanyMaterialEmployee.AddAsync(toAdd);

                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<CompanyMaterialEmployee?> GetByCompanyMaterialEmployeeAsync(
        Guid companyId, Guid materialId, Guid employeeId)
        {
            return await context.CompanyMaterialEmployee
                .AsNoTracking()
                .FirstOrDefaultAsync(cme =>
                    cme.CompanyId == companyId &&
                    cme.MaterialId == materialId &&
                    cme.EmployeeId == employeeId);
        }

    }
}
