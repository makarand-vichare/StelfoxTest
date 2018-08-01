using Net.Core.IDomainServices.Core;
using System.Collections.Generic;
using Net.Core.ViewModels;
using Net.Core.EntityModels.Localization;

namespace Net.Core.IDomainServices.Services
{
    public interface ILocalizationService : IBaseService<LocalizationKey, LocalizationKeyViewModel>
    {
        Dictionary<string, string> GetLocalizations(string keyGroup, string languageCode);
    }
}
