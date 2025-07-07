using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Auth.Interfaces.Services
{
    public interface IEmailConfirmationHandler
    {
        Task HandleAsync(Guid userId, string userName);
    }
}
