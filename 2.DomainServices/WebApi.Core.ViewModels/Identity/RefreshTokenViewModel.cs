using Net.Core.ViewModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Net.Core.ViewModels.Identity.WebApi
{
    public class RefreshTokenViewModel : IdentityColumnViewModel
    {
        public string TokenId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }

        public DateTime IssuedUtc { get; set; }

        public DateTime ExpiresUtc { get; set; }

        [Required]
        public string ProtectedTicket { get; set; }
    }
}
