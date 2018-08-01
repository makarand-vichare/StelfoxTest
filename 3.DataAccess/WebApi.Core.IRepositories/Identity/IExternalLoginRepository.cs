using Net.Core.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;
using Net.Core.EntityModels.Identity;

namespace Net.Core.IRepositories.Identity
{
    public interface IExternalLoginRepository : IIdentityBaseRepository<ExternalLogin>
    {
        ExternalLogin GetByProviderAndKey(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(string loginProvider, string providerKey);
        Task<ExternalLogin> GetByProviderAndKeyAsync(CancellationToken cancellationToken, string loginProvider, string providerKey);
    }
}
