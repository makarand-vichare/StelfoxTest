using Net.Core.ViewModels.Core;

namespace Net.Core.ViewModels.Identity.WebApi
{
    public class UserInfoViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }

    }

}
