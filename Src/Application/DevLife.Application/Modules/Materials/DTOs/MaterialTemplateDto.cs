using DevLife.Domain.Modules.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.DTOs
{
    public class MaterialTemplateDto
    {
        public MaterialTemplateDto()
        {
        }
        public MaterialTemplateDto(MaterialTemplate materialTemplate)
        {
            Id = materialTemplate.Id;
            CompanyId = materialTemplate?.Id ?? Guid.Empty;
            Name = materialTemplate?.Name ?? null;
            Type = materialTemplate?.Type ?? null;
            Description = materialTemplate?.Description ?? null;
            ImageUrl = materialTemplate?.ImageUrl ?? null;
            MaterialSkill = materialTemplate?.MaterialSkill is not null
                ? new MaterialSkillDto(materialTemplate.MaterialSkill)
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
