using Net.Core.IRepositories.Core;
using System.Collections.Generic;
using Net.Core.EntityModels.Localization;

namespace Net.Core.IRepositories.Localization
{
    public interface ILocalizationKeyRepository : IIdentityBaseRepository<LocalizationKey>
    {
        List<LocalizationKey> GetResourceByKeys(List<string> resourceKeys);
    }
}
