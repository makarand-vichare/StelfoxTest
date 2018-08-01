using Net.Core.EntityModels.Core;
using Net.Core.ViewModels.Core;

namespace Net.Core.IDomainServices.Core
{
    public interface IIdentityBaseService<T,VM> : IBaseService<T,VM>  where T : IdentityColumnEntity where VM : IdentityColumnViewModel
    {
    }
}
