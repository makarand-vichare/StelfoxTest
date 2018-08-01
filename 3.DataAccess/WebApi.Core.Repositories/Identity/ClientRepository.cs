using Net.Core.Repositories.Core;
using System.Linq;
using Net.Core.EntityModels.Identity;
using Net.Core.IRepositories.Identity;

namespace Net.Core.Repositories.Identity
{
    public class ClientRepository : IdentityBaseRepository<Client>, IClientRepository
    {
        public ClientRepository()
        {

        }

        public Client FindByClientId(string clientId)
        {
            return DbSet.FirstOrDefault(x => x.ClientId == clientId);
        }
    }
}
