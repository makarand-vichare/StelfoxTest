using Net.Core.ViewModels.Core;

namespace Net.Core.ServiceResponse
{
    public class ResponseResult<VM> : BaseResponseResult
        where VM: BaseViewModel
    {
        public VM ViewModel { get; set; }
    }
}
