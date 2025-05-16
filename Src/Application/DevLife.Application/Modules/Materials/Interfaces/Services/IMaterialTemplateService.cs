using DevLife.Domain.Modules.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.Interfaces.Services
{
    public interface IMaterialTemplateService
    {
        Task<List<MaterialTemplate>> GetAllAsync();

    }
}
