using Net.Core.Repositories.Core;
using System.Threading.Tasks;
using Net.Core.EntityModels.Identity;
using Net.Core.IRepositories.Identity;
using Microsoft.EntityFrameworkCore;

namespace Net.Core.Repositories.Identity
{
    public class RefreshTokenRepository : IdentityBaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository()
        {

        }
        public Task<RefreshToken> FindByTokenIdAsync(string tokenId)
        {
            return DbSet.FirstOrDefaultAsync(x => x.TokenId == tokenId);
        }
    }
}
