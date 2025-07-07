using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.DTOs.Responses
{
    public class ToggleMaterialAssignmentDto
    {
        public Guid MaterialId { get; set; }
        public Guid EmployeeId { get; set; }
        public bool IsAssigned { get; set; }
    }
}
