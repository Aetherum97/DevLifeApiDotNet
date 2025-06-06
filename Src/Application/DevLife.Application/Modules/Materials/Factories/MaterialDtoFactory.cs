using DevLife.Application.Modules.Materials.DTOs.Requests;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.Factories
{
    public static class MaterialDtoFactory
    {
        public static Material Create(MaterialCreateRequest request, Guid companyId)
        {
            var materialId = Guid.NewGuid();
            var result = new Material
            {
                Id = materialId,
                MaterialTemplateId = request.MaterialTemplateId,
                CompanyMaterial = new CompanyMaterial
                {
                    MaterialId = materialId,
                    CompanyId = companyId
                },

            };
            return result;
        }
    }
}
