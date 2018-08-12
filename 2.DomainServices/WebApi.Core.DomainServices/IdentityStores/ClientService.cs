using Net.Core.DomainServices.Core;
using Net.Core.EntityModels.Identity;
using Net.Core.IDomainServices.AutoMapper;
using Net.Core.ViewModels.Identity.WebApi;
using System.Threading.Tasks;
using Net.Core.IDomainServices.IdentityStores;

namespace Net.Core.DomainServices.IdentityStores
{
    public class ClientService : BaseService<Client, ClientViewModel> , IClientService
    {
        public async Task<RefreshTokenViewModel> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await UnitOfWork.RefreshTokenRepository.FindByTokenIdAsync(refreshTokenId);
            var tokenViewModel = refreshToken.ToViewModel<RefreshToken, RefreshTokenViewModel>(Mapper);
            return tokenViewModel;
        }

        public ClientViewModel FindClient(string clientId)
        {
            var clientEntity = UnitOfWork.ClientRepository.FindByClientId(clientId);
            var clientViewModel = clientEntity.ToViewModel<Client, ClientViewModel>(Mapper);

            return clientViewModel;
        }

    }
}
