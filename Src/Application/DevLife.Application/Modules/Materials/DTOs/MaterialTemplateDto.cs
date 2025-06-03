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
            CompanyId = materialTemplate.Id;
            Name = materialTemplate.Name;
            Type = materialTemplate.Type;
            Description = materialTemplate.Description;
            ImageUrl = materialTemplate.ImageUrl;
            MaterialSkill = materialTemplate.MaterialSkill is not null
                ? new MaterialSkillDto(materialTemplate.MaterialSkill)
                : null;
        }
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public MaterialSkillDto? MaterialSkill { get; set; }
    }
}
