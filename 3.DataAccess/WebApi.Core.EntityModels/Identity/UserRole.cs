﻿using Net.Core.EntityModels.Core;

namespace Net.Core.EntityModels.Identity
{
    public class UserRole : IdentityColumnEntity
    {
        #region Fields
        #endregion

        #region Scalar Properties
        public long RoleId { get; set; }
        public long UserId { get; set; }

        #endregion

        #region Navigation Properties
        public User User { get; set; }
        public Role Role { get; set; }

        #endregion
    }
}
