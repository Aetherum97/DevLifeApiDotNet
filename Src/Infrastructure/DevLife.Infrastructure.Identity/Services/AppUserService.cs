﻿using DevLife.Application.Modules.Auth.DTOs.Requests;
using DevLife.Infrastructure.Identity.Entity;
using DevLife.Infrastructure.Identity.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;

namespace DevLife.Infrastructure.Identity.Services
{
    public class AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : IAppUserService
    {
        public async Task<AppUser> CheckAndGeAsync(LoginRequest loginRequest, bool lockoutOnFailur = false)
        {
            var user = await userManager.FindByEmailAsync(loginRequest.Email) ??
                throw new InvalidOperationException("Email or password is incorrect");
            var result = await signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, lockoutOnFailur);

            if (result.IsLockedOut)
            {
                throw new InvalidOperationException("locked from login");
            }

            if (result.IsNotAllowed)
            {
                throw new InvalidOperationException("Invalid Login Attempt");
            }

            if (result.RequiresTwoFactor)
            {
                throw new NotImplementedException("Invalid Login Attempt");
            }

            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Invalid Login Attempt");
            }

            return user;
        }

        public async Task<AppUser> GetByEmailAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email) ??
                throw new InvalidOperationException($"Operation faild");
            return user;
        }


        public async Task<AppUser> CreateAsync(AppUser user, string password)
        {

            var result = await userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Operation failed: Invalid Register Attempt");
            }

            var createdUser = await GetByEmailAsync(user.Email!);

            return createdUser;
        }

        public async Task<IdentityResult> ValidateEmailAsync(string email, string token)
        {

            var user = await userManager.FindByEmailAsync(email) ??
                throw new InvalidOperationException($"Operation faild: Invalid Email Confirmation Attempt");
            if (user.EmailConfirmed)
            {
                throw new InvalidOperationException($"Operation faild: Invalid Email Confirmation Attempt");
            }
            var result = await userManager.ConfirmEmailAsync(user, token) ??
                throw new InvalidOperationException($"Operation faild: Invalid Email Confirmation Attempt");

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Operation failed: Invalid Email Confirmation Attempt");
            }

            return result;

        }

        public async Task<IEnumerable<Claim>> GenarateClaimsAsync(AppUser user)
        {
            var userClaims = (await signInManager.ClaimsFactory.CreateAsync(user)).Claims;
            return userClaims;
        }

        public async Task<string> GenerateEmailTokenAsync(AppUser user)
        {
            return await userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public AppUser MapToAppUser(RegisterRequest user)
        {
            return new AppUser
            {
                UserName = user.UserName,
                Email = user.Email,
            };
        }
    }
}
