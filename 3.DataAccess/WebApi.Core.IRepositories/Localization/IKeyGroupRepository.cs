using Net.Core.IRepositories.Core;
using System.Collections.Generic;
using Net.Core.EntityModels.Localization;

namespace Net.Core.IRepositories.Localization
{
    public interface IKeyGroupRepository : IIdentityBaseRepository<KeyGroup>
    {
        KeyGroup GetResourceKeysByGroup(string groupId);
        List<KeyGroup> GetResourceKeysByGroups(List<string> groupIds);
    }
}
