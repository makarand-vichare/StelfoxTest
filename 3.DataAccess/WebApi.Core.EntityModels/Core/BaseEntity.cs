using System;
using System.ComponentModel.DataAnnotations;

namespace Net.Core.EntityModels.Core
{
    [Serializable]
    public abstract  class BaseEntity
    {
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
