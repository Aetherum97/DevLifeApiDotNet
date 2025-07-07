using DevLife.Application.Modules.Auth.Interfaces.Services;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Domain.Modules.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Modules.Companies.Handlers
{
    public class EmailConfirmationHandler(
        ICompanyRepository companyRepository,
        IPlayerRepository playerRepository) : IEmailConfirmationHandler
    {
      public async Task HandleAsync(Guid userId, string userName)
        {
            var exists = await playerRepository.IsExistsByUserIdAsync(userId);
            if (exists)
            {
                return;
            }

            var newCompany = new Company
            {
                Name = $"{userName}'s Company",
                Experience = 0
            };

            await companyRepository.CreateAsync(newCompany);

            var newPlayer = new Player
            {
                PlayerName = userName,
                IsTutorialFinished = false,
                UserId = userId,
                CompanyId = newCompany.Id
            };
            await playerRepository.CreateAsync(newPlayer);
        }
    }
}
