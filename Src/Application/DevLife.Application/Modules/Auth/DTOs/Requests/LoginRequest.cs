using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevLife.Application.Modules.Auth.DTOs.Requests
{
    public class LoginRequest
    {
        [Required]
        [DefaultValue("admin@admin")]
        public required string Email { get; set; }

        [Required]
        [DefaultValue("admin")]
        public required string Password { get; set; }
    }
}
