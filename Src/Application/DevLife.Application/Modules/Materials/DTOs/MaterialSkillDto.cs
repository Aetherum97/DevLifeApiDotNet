using DevLife.Domain.Modules.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.DTOs
{
    public class MaterialSkillDto
    {
        public MaterialSkillDto()
        {
        }
        public MaterialSkillDto(MaterialSkill materialSkill)
        {
            Id = materialSkill.Id;
            Name = materialSkill.Name;
            Modificator = materialSkill.Modificator;
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? Modificator { get; set; }

    }
}
