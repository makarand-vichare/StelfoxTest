using Net.Core.EntityModels.Location;
using Net.Core.IDomainServices.Core;
using Net.Core.ServiceResponse;
using Net.Core.ViewModels;

namespace Net.Core.IDomainServices.Services
{
    public interface ICountryService : IBaseService<Country, CountryViewModel>
    {
        ResponseResults<LookUpViewModel> GetLookup();
    }
}
