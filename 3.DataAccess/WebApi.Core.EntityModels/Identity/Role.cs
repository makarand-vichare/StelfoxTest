using Net.Core.EntityModels.Core;
using System.Collections.Generic;

namespace Net.Core.EntityModels.Identity
{
    public class Role : IdentityColumnEntity
    {

        #region Scalar Properties
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
