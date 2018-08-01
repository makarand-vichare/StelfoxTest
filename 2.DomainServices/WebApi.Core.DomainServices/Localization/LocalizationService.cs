using Net.Core.DomainServices.Core;
using Net.Core.IDomainServices.Services;
using Net.Core.ViewModels;
using Net.Core.EntityModels.Localization;
using System.Collections.Generic;
using System;
using System.Linq;
using Net.Core.Utility;
using Net.Core.InfraStructure.Logging;

namespace Net.Core.DomainServices
{
    public class LocalizationService : BaseService<LocalizationKey, LocalizationKeyViewModel>, ILocalizationService
    {
        public Dictionary<string,string> GetLocalizations(string keyGroup, string languageCode)
        {
            var localizationKeys = new Dictionary<string, string>();
            try
            {
                var resourceKeyModel = UnitOfWork.KeyGroupRepository.GetResourceKeysByGroup(keyGroup);
                if(resourceKeyModel != null )
                {
                    var resourceKeys = resourceKeyModel.LocalizationKeys.Split(',').ToList();
                    var resourceValues = UnitOfWork.LocalizationKeyRepository.GetResourceByKeys(resourceKeys);
                    if (resourceValues != null && resourceValues.Count > 0)
                    {
                        if (languageCode == AppConstants.IrishLanguage)
                        {
                            localizationKeys = resourceValues.ToDictionary(o => o.LocalizationKeyCode, o => o.IrishValue);
                        }
                        else
                        {
                            localizationKeys = resourceValues.ToDictionary(o => o.LocalizationKeyCode, o => o.EnglishValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Instance.Log(ex.Message);
            }
            return localizationKeys;
        }

    }
}
