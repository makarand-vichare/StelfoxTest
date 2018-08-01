﻿using Net.Core.Repositories.Core;
using System.Collections.Generic;
using System.Linq;
using Net.Core.EntityModels.Localization;
using Net.Core.IRepositories.Localization;

namespace Net.Core.Repositories.Localization
{
    public class KeyGroupRepository : IdentityBaseRepository<KeyGroup>, IKeyGroupRepository
    {

        public KeyGroup GetResourceKeysByGroup(string groupId)
        {
            if (!string.IsNullOrWhiteSpace(groupId))
            {

                return DbSet.FirstOrDefault(o => o.KeyGroupCode.ToLower().Trim() == groupId.ToLower().Trim());
            }
            else
            {
                return null;
            }
        }

        public List<KeyGroup> GetResourceKeysByGroups(List<string> groupIds)
        {
            if (groupIds != null && groupIds.Count > 0)
            {
                return DbSet.Where(o => groupIds.Contains(o.KeyGroupCode.ToLower().Trim())).ToList();
            }
            else
            {
                return new List<KeyGroup>();
            }
        }
    }
}
