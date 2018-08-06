using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using WebApi.Core2.StructureMap;

public static class ConfigureIocExtension
{
    public static IServiceProvider ConfigureIoc(this IServiceCollection services)
    {
        var container = StructureMapConfig.RegisterComponents();

        container.Configure(config =>
        {
            //////config.ForSingletonOf<IHttpContextAccessor>().Use<HttpContextAccessor>();
            //////// Identity services
            ////////config.ForSingletonOf<IdentityMarkerService>();
            //////config.For<IUserValidator<IdentityUserViewModel>>().Use<UserValidator<IdentityUserViewModel>>();
            //////config.For<IPasswordValidator<IdentityUserViewModel>>().Use<PasswordValidator<IdentityUserViewModel>>();
            //////config.For<IPasswordHasher<IdentityUserViewModel>>().Use<PasswordHasher<IdentityUserViewModel>>();
            //////config.For<IOptions<IdentityOptions>>().Use<OptionsAccessor>();

            //////config.For<ILookupNormalizer>().Use<UpperInvariantLookupNormalizer>();
            //////config.For<IRoleValidator<IdentityRoleViewModel>>().Use<RoleValidator<IdentityRoleViewModel>>();
            //////// No interface for the error describer so we can add errors without rev'ing the interface
            //////config.For<IdentityErrorDescriber>();
            //////config.For<ISecurityStampValidator>().Use<SecurityStampValidator<IdentityUserViewModel>>();
            //////config.For<IUserClaimsPrincipalFactory<IdentityUserViewModel>>().Use<UserClaimsPrincipalFactory <IdentityUserViewModel, IdentityRoleViewModel>>();
            //////config.For<UserManager<IdentityUserViewModel>>().Use<UserManager<IdentityUserViewModel>>();
            //////config.For<SignInManager<IdentityUserViewModel>>().Use<SignInManager<IdentityUserViewModel>>();
            //////config.For<RoleManager<IdentityRoleViewModel>>().Use<RoleManager<IdentityRoleViewModel>>();
            config.Populate(services);
        });
        return container.GetInstance<IServiceProvider>();
    }
}