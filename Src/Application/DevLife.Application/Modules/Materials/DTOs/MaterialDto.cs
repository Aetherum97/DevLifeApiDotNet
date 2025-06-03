using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.DTOs
{
    public class MaterialDto
    {
        public Guid Id { get; set; }
        public MaterialTemplateDto? MaterialTemplate { get; set; }
    }
}
