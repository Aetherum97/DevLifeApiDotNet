using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Companies.DTOs
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public required string PlayerName { get; set; }
        public bool IsTutorialFinished { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
    }
}
