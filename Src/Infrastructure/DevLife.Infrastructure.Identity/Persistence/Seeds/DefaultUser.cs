﻿using DevLife.Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;

namespace DevLife.Infrastructure.Identity.Persistence.Seeds
{
    public static class DefaultUser
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager)
        {
            var defaultUser = new AppUser
            {
                UserName = "admin",
                Email = "admin@admin",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(defaultUser.Email);

            if (user == null)
            {
                var result = await userManager.CreateAsync(defaultUser, "admin");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }
            }
            else
            {
                if (!await userManager.IsInRoleAsync(user, "Admin"))
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }

    }
}
