using Net.Core.EntityModels.Location;
using Net.Core.IDomainServices.Core;
using Net.Core.ServiceResponse;
using Net.Core.ViewModels;

namespace Net.Core.IDomainServices.Services
{
    public interface ICityService : IBaseService<City, CityViewModel>
    {
        ResponseResults<LookUpViewModel> GetLookup(long countryId);
    }
}
