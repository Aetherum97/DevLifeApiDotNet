namespace DevLife.Application.Commons.Interfaces.Services;

public interface IAuthenticatedUserService
{
    string UserId { get; set; }
    string CompanyId { get; }
    string UserName { get; }


    Guid GetUserId();
    Guid GetCompanyId();
}
