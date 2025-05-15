using DevLife.Application.Modules.Materials.Interfaces;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Modules.Materials.Repositories
{
    public sealed class MaterialTemplateRepository(AppDbContext context): BaseRepository<MaterialTemplate>(context), IMaterialTemplateRepository
    {
    }
}
