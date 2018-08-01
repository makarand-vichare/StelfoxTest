using Net.Core.EntityModels.Identity;
using Net.Core.IRepositories.Core;

namespace Net.Core.IRepositories.Identity
{
    public interface IClientRepository : IIdentityBaseRepository<Client>
    {
        Client FindByClientId(string clientId);

    }
}
