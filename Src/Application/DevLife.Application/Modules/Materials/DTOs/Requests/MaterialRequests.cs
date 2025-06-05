using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.DTOs.Requests
{
    public class MaterialCreateRequest
    {
        public Guid MaterialTemplateId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
