using Net.Core.IDomainServices.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Net.Core.ViewModels.Identity.WebApi;
using Net.Core.EntityModels.Identity;

namespace Net.Core.IDomainServices.IdentityStores
{
    public interface IRefreshTokenService : IBaseService<RefreshToken, RefreshTokenViewModel>
    {
        Task<bool> AddRefreshToken(RefreshTokenViewModel token);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<bool> RemoveRefreshToken(RefreshTokenViewModel refreshToken);
        Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId);
        List<RefreshTokenViewModel> GetAllRefreshTokens();
    }
}
