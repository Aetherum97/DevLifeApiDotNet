using DevLife.Application.Commons.DTOs;
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
        public string? Name { get; set; }
        public int Experience { get; set; }
        public Guid PlayerId { get; set; }
    }
}
