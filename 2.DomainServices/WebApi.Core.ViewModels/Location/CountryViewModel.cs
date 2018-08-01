using Net.Core.ViewModels.Core;
using System;

namespace Net.Core.ViewModels
{
    [Serializable]
    public class CountryViewModel : IdentityColumnViewModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
