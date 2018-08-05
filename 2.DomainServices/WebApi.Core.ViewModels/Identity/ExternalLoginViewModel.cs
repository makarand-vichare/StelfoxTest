using System.ComponentModel.DataAnnotations;

namespace Net.Core.ViewModels.Identity.WebApi
{
    public class ExternalLoginViewModel 
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
