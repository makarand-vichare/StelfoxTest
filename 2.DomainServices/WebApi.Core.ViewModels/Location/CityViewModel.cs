using Net.Core.ViewModels.Core;
using System;

namespace Net.Core.ViewModels
{
    [Serializable]
    public class CityViewModel : IdentityColumnViewModel
    {
        public long CountryId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    }
}
