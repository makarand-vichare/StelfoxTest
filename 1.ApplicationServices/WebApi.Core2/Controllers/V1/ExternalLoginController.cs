using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net.Core.ViewModels.Identity.WebApi;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Core2.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ExternalLoginController : BaseController
    {
        private readonly UserManager<IdentityUserViewModel> _userManager;
        private readonly SignInManager<IdentityUserViewModel> _signInManager;

        public ExternalLoginController(
            UserManager<IdentityUserViewModel> userManager,
            SignInManager<IdentityUserViewModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet, Route("Login"), AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(LoginCallback), "ExternalLogin", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet, Route("LoginCallback"), AllowAnonymous]
        public async Task<IActionResult> LoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                //ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            return Ok(new { result, email, info.LoginProvider, returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new IdentityUserViewModel { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        //_logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return Ok(returnUrl);
                    }
                }
                AddErrors(result);
            }

            return Ok(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}