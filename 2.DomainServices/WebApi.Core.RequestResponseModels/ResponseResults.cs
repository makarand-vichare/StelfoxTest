using System.Collections.Generic;
using Net.Core.ViewModels.Core;

namespace Net.Core.ServiceResponse
{
    public class ResponseResults<VM> : BaseResponseResult  where VM: BaseViewModel
    {
        public List<VM> ViewModels { get; set; } 
    }
}
