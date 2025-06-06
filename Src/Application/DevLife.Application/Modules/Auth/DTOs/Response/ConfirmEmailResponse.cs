namespace DevLife.Application.Modules.Auth.DTOs.Response
{
    public class ConfirmEmailResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
    }
}
