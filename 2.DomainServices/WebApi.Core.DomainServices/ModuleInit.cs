using Net.Core.DomainServices.IdentityStores;
using Net.Core.IDomainServices.IdentityStores;
using Net.Core.IDomainServices.Queues;
using Net.Core.ViewModels.Identity.WebApi;
using Net.Core.IDomainServices.Services;
using Net.Core.Common.MEF;
using System.Composition;
using Microsoft.AspNetCore.Identity;

namespace Net.Core.DomainServices
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType(typeof(IUserStore<IdentityUserViewModel>), typeof(CustomUserStore));
            registrar.RegisterType(typeof(IRoleStore<IdentityRoleViewModel>), typeof(CustomRoleStore));

            registrar.RegisterType<IEmailQueueService, EmailQueueService>();
            registrar.RegisterType<IPdfQueueService, PdfQueueService>();
            registrar.RegisterType<IRequestQueueService, RequestQueueService>();

            registrar.RegisterType<IClientService, ClientService>();
            registrar.RegisterType<IRefreshTokenService, RefreshTokenService>();

            registrar.RegisterType<ICityService, CityService>();
            registrar.RegisterType<ICountryService, CountryService>();

            registrar.RegisterType<ILocalizationService, LocalizationService>();
        }
    }
}
