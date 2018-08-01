using Net.Core.ViewModels.Core;
using System;

namespace Net.Core.ViewModels
{
    [Serializable]
    public class LookUpViewModel : IdentityColumnViewModel
    {
        public string Value { get; set; }
    }
}
