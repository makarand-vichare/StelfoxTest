using Net.Core.EntityModels.Location;
using Net.Core.IRepositories.Core;

namespace Net.Core.IRepositories.Location
{
    public interface ICountryRepository : IIdentityBaseRepository<Country>
    {
        //IEnumerable<CountryEntityModel> GetCountries();
    }
}
