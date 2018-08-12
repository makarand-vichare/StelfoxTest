using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net.Core.IDomainServices.IdentityStores;
using Net.Core.ViewModels;
using Net.Core.ViewModels.Identity.WebApi;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core2.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : BaseController
    {
        private SignInManager<IdentityUserViewModel> signInManager;
        private UserManager<IdentityUserViewModel> userManager;


        public AuthController(SignInManager<IdentityUserViewModel> _signInManager, UserManager<IdentityUserViewModel> _userManager)
        {
                signInManager = _signInManager;
                userManager = _userManager;
         }


        // GET api/values
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel viewModel)
        {
            if (viewModel == null)
            {
                return BadRequest("Invalid client request");
            }

            var result = await signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(new IdentityUserViewModel { Email = viewModel.Email});
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, viewModel.Email),
                    new Claim(ClaimTypes.Role, string.Join(",",userRoles))
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            //_logger.LogInformation("User logged out.");
            return Ok("Home");
        }

    }
}