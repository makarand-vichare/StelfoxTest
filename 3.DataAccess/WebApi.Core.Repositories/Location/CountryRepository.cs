﻿using Net.Core.EntityModels.Location;
using Net.Core.IRepositories.Location;
using Net.Core.Repositories.Core;

namespace Net.Core.Repositories.Location
{
    public class CountryRepository : IdentityBaseRepository<Country>, ICountryRepository
    {
        //public IEnumerable<CountryEntityModel> GetCountries()
        //{
        //    return DbSet.ToList();
        //}
    }
}
