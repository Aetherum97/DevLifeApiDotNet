using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Companies.DTOs
{
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int Experience { get; set; }
        public PlayerDto? Player { get; set; }
        public IEnumerable<CompanyEmployeeDto>? CompanyEmployees { get; set; }
        public IEnumerable<CompanyContractDto>? CompanyContracts { get; set; }
        public IEnumerable<CompanyMaterialDto>? CompanyMaterials { get; set; }
    }
}
