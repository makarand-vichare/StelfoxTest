using Net.Core.ViewModels.Core;

namespace Net.Core.ViewModels.Identity.WebApi
{
    public class UserLoginInfoViewModel : BaseViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }


    }

}
