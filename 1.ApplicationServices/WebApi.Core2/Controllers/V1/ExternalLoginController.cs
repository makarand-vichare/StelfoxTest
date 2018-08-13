using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Net.Core.Utility;
using Net.Core.ViewModels.Identity.WebApi;
using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core2.Controllers.V1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ExternalLoginController : BaseController
    {
        private readonly UserManager<IdentityUserViewModel> userManager;
        private readonly SignInManager<IdentityUserViewModel> signInManager;

        public ExternalLoginController(
            UserManager<IdentityUserViewModel> _userManager,
            SignInManager<IdentityUserViewModel> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpGet, Route("Login"), AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(string provider,string clientId, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
             signInManager.SignOutAsync().Wait();

            var redirectUrl = Url.Action(nameof(LoginCallback), "ExternalLogin", new { returnUrl, clientId });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet, Route("LoginCallback")]
        public async Task<IActionResult> LoginCallback(string returnUrl = null, string clientId = null, string remoteError = null)
        {
            var javascriptContent = new StringBuilder();
            var returnPageName = "";
            if (remoteError != null)
            {
                //ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            // Sign in the user with this external login provider if the user already has a login.
            //TODO: extend this method for client id
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);


            if (result.Succeeded)
            {
                if (result.IsLockedOut || result.IsNotAllowed)
                {
                    returnPageName = "lockedOut/" + info.LoginProvider + "/" + result.IsLockedOut+ "/" + result.IsNotAllowed + "/" + email;
                }

                var user = await userManager.FindByEmailAsync(email);

                await signInManager.SignInAsync(user, isPersistent: false);

                returnPageName = (user.RoleName == UserRoles.Admin.ToString()) ? "adminlanding" : "userlanding";
                returnPageName += "/" + true + "/" + user.UserName + "/" + user.RoleName + "/" + user.Id;
            }
            else
            {
                returnPageName = "registerExternal/" + info.LoginProvider + "/" + info.ProviderKey + "/" + info.ProviderDisplayName + "/" + email;
            }

            javascriptContent.Append("<script type=\"text/javascript\">");
            javascriptContent.Append("window.location=\""+ returnUrl + returnPageName + "\"");
            //javascriptContent.Append("window.opener.externalProviderLogin(");
            //javascriptContent.Append(JsonConvert.SerializeObject(new { result, email, info.LoginProvider, returnUrl }));
            //javascriptContent.Append(");");
            //javascriptContent.Append("window.close();");
            javascriptContent.Append("</script>");

            return Content(javascriptContent.ToString(), "text/html");
        }

        [HttpPost, Route("LoginConfirmation")]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginConfirmation([FromBody]ExternalLoginViewModel registration)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                //var info = await signInManager.GetExternalLoginInfoAsync();
                //if (info == null)
                //{
                //    throw new ApplicationException("Error loading external login information during confirmation.");
                //}
                var info = new UserLoginInfo(registration.LoginProvider, registration.ProviderKey, registration.ProviderDisplayName);
                var user = new IdentityUserViewModel { UserName = AppMethods.GenerateUserName(registration.Email), Email = registration.Email };
                var response = await userManager.CreateAsync(user);
                if (response.Succeeded)
                {
                    response = await userManager.AddToRoleAsync(user, UserRoles.User.ToString());
                }
                if (response.Succeeded)
                {
                    user.RoleName = UserRoles.User.ToString();
                    response = await userManager.AddLoginAsync(user, info);
                    if (response.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        //_logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return Ok(new { UserInfo = user, IsAuth = true});
                    }
                }
                AddErrors(response);
            }

            return BadRequest(ModelState);
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