using Net.Core.EntityModels.Identity;
using Net.Core.IDomainServices.Core;
using Net.Core.ViewModels.Identity.WebApi;

namespace Net.Core.IDomainServices.IdentityStores
{
    public interface IClientService : IBaseService<Client, ClientViewModel>
    {
        ClientViewModel FindClient(string clientId);
        
    }
}
