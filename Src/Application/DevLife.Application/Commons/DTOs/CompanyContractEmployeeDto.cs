using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Commons.DTOs
{
    public class CompanyContractEmployeeDto
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ContractId { get; set; }
        public CompanyContractDto? CompanyContract { get; set; }
        public CompanyEmployeeDto? CompanyEmployee { get; set; }
    }
}
