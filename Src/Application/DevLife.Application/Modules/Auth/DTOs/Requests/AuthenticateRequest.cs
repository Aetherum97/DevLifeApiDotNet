namespace DevLife.Application.Modules.Auth.DTOs.Requests
{
    public class AuthenticateRequest
    {
        public required string RefreshToken { get; set; }
    }
}
