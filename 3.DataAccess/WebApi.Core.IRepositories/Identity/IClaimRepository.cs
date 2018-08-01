using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Net.Core.EntityModels.Identity;
using Net.Core.IRepositories.Core;

namespace Net.Core.IRepositories.Identity
{
    public interface IClaimRepository : IIdentityBaseRepository<Claim>
    {
        Claim FindByType(string claimType);
        Task<Claim> FindByTypeAsync(CancellationToken cancellationToken, string claimType);
        Task<Claim> FindByTypeAsync(string claimType);
        List<long> GetUserIdsByClaim(System.Security.Claims.Claim claim);
    }
}