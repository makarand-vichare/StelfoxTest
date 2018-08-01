using Net.Core.EntityModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Net.Core.EntityModels.Queues
{
    [Serializable]
    public class RequestQueue : IdentityColumnEntity
    {

        [Required]
        public string SearchParameters { get; set; }

        [Required]
        public bool IsRequestSucceed { get; set; }

        public string ErrorMessage { get; set; }

    }
}
