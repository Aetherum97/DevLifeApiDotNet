using DevLife.Application.Commons.DTOs;
using DevLife.Domain.Modules.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Companies.DTOs
{
    public class CompanyDto
    {
        public CompanyDto() { }
        public CompanyDto(Company company)
        {
            Id = company.Id;
            PlayerId = company.Player?.Id ?? Guid.Empty;
            Name = company.Name;
            Experience = company.Experience;
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Experience { get; set; }
        public Guid PlayerId { get; set; }
    }
}
