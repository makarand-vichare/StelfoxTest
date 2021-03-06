﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Net.Core.EntityModels.Core
{
    public class IdentityColumnEntity :BaseEntity
    {
        //[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
