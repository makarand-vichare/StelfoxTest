using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core2.BindingModels
{
    public class ErrorBindingModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
