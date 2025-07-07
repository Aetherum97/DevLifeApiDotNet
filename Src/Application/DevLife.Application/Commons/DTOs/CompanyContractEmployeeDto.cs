using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Domain.Commons.Entity;

namespace DevLife.Application.Commons.DTOs
{
    public class CompanyContractEmployeeDto
    {
        public CompanyContractEmployeeDto()
        { }
        public CompanyContractEmployeeDto(CompanyContractEmployee assignement)
        {
            Id = assignement.Id;
            CompanyId = assignement.CompanyId;
            EmployeeId = assignement.EmployeeId;
            ContractId = assignement.ContractId;
        }

        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ContractId { get; set; }
    }
}
