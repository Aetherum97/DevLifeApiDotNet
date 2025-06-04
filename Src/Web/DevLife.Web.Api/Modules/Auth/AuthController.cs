using System.Web;
using DevLife.Application.Modules.Auth.DTOs.Requests;
using DevLife.Application.Modules.Auth.Interfaces.Services;
using DevLife.Web.Api.Commons.Factories;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthentificationService authentification) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var res = await authentification.RegisterAsync(request);
            return Ok(res);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var res = await authentification.LoginAsync(request);
            Response.Cookies.Append("refreshToken", res.RefreshToken!.Token, CookieFactory.CookieOptions(res.RefreshToken!.ExpirationDate));
            return Ok(res);

        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {


            Response.Cookies.Delete("refreshToken", new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,

            });

            return Ok();

        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate()
        {

            Request.Cookies.TryGetValue("refreshToken", out var refreshToken);

            if (refreshToken == null)
            {
                return NotFound();
            }

            var req = new AuthenticateRequest
            {
                RefreshToken = refreshToken
            };

            var res = await authentification.AuthenticateAsync(req);

            if (!res.Success)
            {
                return StatusCode(500, new { message = "An unexpected error occurred:  " });
            }

            return Ok(res);
        }


        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
                return BadRequest("Invalide URL");

            var queryParams = HttpUtility.ParseQueryString(Request.QueryString.Value!);
            var correctedToken = queryParams["token"];

            if (string.IsNullOrEmpty(correctedToken))
                return BadRequest("Invalide URL");

            var request = new ConfirmEmailRequest
            {
                Email = email,
                Token = token
            };

            var res = await authentification.ConfirmEmailAsync(request);

            if (!res.Success)
            {
                return StatusCode(500, new { message = "An unexpected error occurred" });
            }

            return Ok(res);
        }
    }
}
