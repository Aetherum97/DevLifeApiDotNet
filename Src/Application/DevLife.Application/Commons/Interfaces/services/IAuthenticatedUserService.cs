namespace DevLife.Application.Commons.Interfaces.Services;
public interface IAuthenticatedUserService
{
    string UserId { get; }
    string UserName { get; }
}
