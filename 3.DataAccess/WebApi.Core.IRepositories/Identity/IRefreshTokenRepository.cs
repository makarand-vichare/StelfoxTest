using Net.Core.IRepositories.Core;
using System.Threading.Tasks;
using Net.Core.EntityModels.Identity;

namespace Net.Core.IRepositories.Identity
{
    public interface IRefreshTokenRepository : IIdentityBaseRepository<RefreshToken>
    {
        Task<RefreshToken> FindByTokenIdAsync(string tokenId);
    }
}
