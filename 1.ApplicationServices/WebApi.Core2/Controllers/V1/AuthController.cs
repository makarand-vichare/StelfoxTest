using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net.Core.IDomainServices.IdentityStores;
using Net.Core.ViewModels;
using Net.Core.ViewModels.Identity.WebApi;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Net.Core.Utility;
using Microsoft.Extensions.Configuration;

namespace WebApi.Core2.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : BaseController
    {
        private SignInManager<IdentityUserViewModel> signInManager;
        private UserManager<IdentityUserViewModel> userManager;
        private IConfiguration configuration;


        public AuthController(SignInManager<IdentityUserViewModel> _signInManager, 
                                UserManager<IdentityUserViewModel> _userManager,
                                IConfiguration _configuration)
        {
                signInManager = _signInManager;
                userManager = _userManager;
                configuration = _configuration;
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
                var user = await userManager.FindByEmailAsync(viewModel.Email);
                user.RoleName = userRoles.FirstOrDefault();

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConstants.TokenPrivateKey));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, viewModel.Email),
                    new Claim(ClaimTypes.Role, string.Join(",",userRoles))
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: configuration.GetValue<string>(AppConstants.BaseUrlKey),
                    audience: configuration.GetValue<string>(AppConstants.BaseUrlKey),
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(350),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, UserInfo = user, IsAuth = true });
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