using Net.Core.IRepositories.Core;
using System.Threading;
using System.Threading.Tasks;
using Net.Core.EntityModels.Identity;

namespace Net.Core.IRepositories.Identity
{
    public interface IRoleRepository : IIdentityBaseRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
