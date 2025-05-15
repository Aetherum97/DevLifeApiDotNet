using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Modules.Materials.Repositories
{
    public sealed class MaterialSkillRepository(AppDbContext context) : BaseRepository<MaterialSkill>(context), IMaterialSkillRepository
    {
    }
}
