﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.DTOs
{
    public class MaterialSkillDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Modificator { get; set; }

    }
}
