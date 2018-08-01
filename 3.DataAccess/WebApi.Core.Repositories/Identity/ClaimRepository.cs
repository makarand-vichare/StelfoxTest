using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net.Core.EntityModels.Identity;
using Net.Core.IRepositories.Identity;
using Net.Core.Repositories.Core;

namespace Net.Core.Repositories.Identity
{
    public class ClaimRepository : IdentityBaseRepository<Claim>, IClaimRepository
    {

        public Claim FindByType(string claimType)
        {
            return DbSet.FirstOrDefault(x => x.ClaimType == claimType);
        }

        public Task<Claim> FindByTypeAsync(string claimType)
        {
            return DbSet.FirstOrDefaultAsync(x => x.ClaimType == claimType);
        }

        public Task<Claim> FindByTypeAsync(System.Threading.CancellationToken cancellationToken, string claimType)
        {
            return DbSet.FirstOrDefaultAsync(x => x.ClaimType == claimType, cancellationToken);
        }

        public List<long> GetUserIdsByClaim(System.Security.Claims.Claim claim)
        {
            return DbSet.Where(x => x.ClaimType == claim.Type && x.ClaimValue == claim.Value).Select(o=>o.UserId).ToList();
        }

    }
}
