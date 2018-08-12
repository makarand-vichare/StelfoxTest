using AutoMapper;
using Net.Core.EntityModels.Core;
using Net.Core.EntityModels.Identity;
using Net.Core.EntityModels.Queues;
using Net.Core.Utility;
using Net.Core.ViewModels;
using Net.Core.ViewModels.Core;
using Net.Core.ViewModels.Identity.WebApi;

namespace Net.Core.IDomainServices.AutoMapper
{
    public class ModelAutoMapperProfiler : Profile
    {
        public ModelAutoMapperProfiler()
        {
           CreateMap<BaseEntity, BaseViewModel>().ReverseMap();
           CreateMap<AuditableEntity, AuditableViewModel>().ReverseMap();
           CreateMap<IdentityColumnEntity, IdentityColumnViewModel>().ReverseMap();

            CreateMap<User, IdentityUserViewModel>()
                             //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                             .ReverseMap()
                             //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                             .ForMember(dest => dest.Claims, opt => opt.Ignore())
                             .ForMember(dest => dest.UserRoles, opt => opt.Ignore());

           CreateMap<Role, IdentityRoleViewModel>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
           CreateMap<IdentityRoleViewModel, Role>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

           CreateMap<EmailQueue, EmailQueueViewModel>().ReverseMap();
           CreateMap<RequestQueue, RequestQueueViewModel>().ReverseMap();
           CreateMap<PdfQueue, PdfQueueViewModel>().ReverseMap();


           CreateMap<Client, ClientViewModel>()
                .ForMember(dest => dest.ApplicationType, opt => opt.ResolveUsing<ApplicationTypeEnumResolver, string>(src => src.ApplicationType));

           CreateMap<ClientViewModel, Client>()
                            .ForMember(dest => dest.ApplicationType, opt => opt.ResolveUsing<ApplicationTypeIntResolver, ApplicationTypes>(src => src.ApplicationType));

           CreateMap<RefreshToken, RefreshTokenViewModel>().ReverseMap();

           CreateMap<ExternalLogin, ExternalLoginViewModel>().ReverseMap();

           CreateMap<ExternalLogin, UserLoginInfoViewModel>().ReverseMap();


        }
    }
}
