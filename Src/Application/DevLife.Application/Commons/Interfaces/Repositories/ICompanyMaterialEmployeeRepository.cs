using DevLife.Domain.Commons.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Commons.Interfaces.Repositories
{
    public interface ICompanyMaterialEmployeeRepository : IBaseRepository<CompanyMaterialEmployee>
    {
        Task<bool> ToggleAssignmentAsync(Guid companyId, Guid materialId, Guid employeeId);
    }
}
