using System.ComponentModel.DataAnnotations;

namespace Net.Core.ViewModels.Identity.WebApi
{
    public class ExternalLoginViewModel 
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
    }

}
