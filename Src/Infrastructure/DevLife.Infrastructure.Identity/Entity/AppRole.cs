using Microsoft.AspNetCore.Identity;

namespace DevLife.Infrastructure.Identity.Entity
{
    public class AppRole(string name) : IdentityRole<Guid>(name)
    {
    }
}
