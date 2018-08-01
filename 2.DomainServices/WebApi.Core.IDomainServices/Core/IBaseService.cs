using Net.Core.EntityModels.Core;
using Net.Core.ServiceResponse;
using Net.Core.ViewModels.Core;

namespace Net.Core.IDomainServices.Core
{
    public interface IBaseService<T,VM>  where T : BaseEntity where VM : BaseViewModel
    {
        ResponseResults<VM> GetAll();
        ResponseResult<VM> Save(VM viewModel);
    }
}
