﻿using Net.Core.EntityModels.Core;

namespace Net.Core.EntityModels.Location
{
    public class Country : IdentityColumnEntity
    {
        #region Scalar Properties
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
