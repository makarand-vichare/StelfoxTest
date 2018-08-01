using Net.Core.Repositories.Core;
using Net.Core.Repositories.Identity;
using Net.Core.Repositories.Queues;
using Net.Core.Repositories.Location;
using Net.Core.Repositories.Localization;
using Net.Core.Common.MEF;
using System.Composition;
using Net.Core.IRepositories.Core;
using Net.Core.IRepositories.Queues;
using Net.Core.IRepositories.Identity;
using Net.Core.IRepositories.Location;
using Net.Core.IRepositories.Localization;

namespace Net.Core.Repositories
{
    [Export(typeof(IModule))]
    public class ModuleInit : IModule
    {
        public void Initialize(IModuleRegistrar registrar)
        {
            registrar.RegisterType<IUnitOfWork, UnitOfWork>();
            registrar.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            registrar.RegisterType<IEmailQueueRepository, EmailQueueRepository>();
            registrar.RegisterType<IPdfQueueRepository, PdfQueueRepository>();
            registrar.RegisterType<IRequestQueueRepository, RequestQueueRepository>();
            registrar.RegisterType<IUserRepository, UserRepository>();
            registrar.RegisterType<IRoleRepository, RoleRepository>();
            registrar.RegisterType<IExternalLoginRepository, ExternalLoginRepository>();
            registrar.RegisterType<IRefreshTokenRepository, RefreshTokenRepository>();
            registrar.RegisterType<IClientRepository, ClientRepository>();

            registrar.RegisterType<ICityRepository, CityRepository>();
            registrar.RegisterType<ICountryRepository, CountryRepository>();

            registrar.RegisterType<IKeyGroupRepository, KeyGroupRepository>();
            registrar.RegisterType<ILocalizationKeyRepository, LocalizationKeyRepository>();

        }
    }
}
