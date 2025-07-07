using DevLife.Domain.Modules.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.DTOs
{
    public class MaterialDto
    {
        public MaterialDto()
        {
        }

        public MaterialDto(Material material)
        { 
            Id = material.Id;
            CompanyId = material.CompanyMaterial?.CompanyId ?? Guid.Empty;
            Name = material.MaterialTemplate?.Name ?? null;
            Type = material.MaterialTemplate?.Type ?? null;
            Description = material.MaterialTemplate?.Description ?? null;
            ImageUrl = material.MaterialTemplate?.ImageUrl ?? null;
            MaterialSkill = material.MaterialTemplate?.MaterialSkill is not null
                ? new MaterialSkillDto(material.MaterialTemplate!.MaterialSkill)
                : null;
        }
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public MaterialSkillDto? MaterialSkill { get; set; }
    }
}
