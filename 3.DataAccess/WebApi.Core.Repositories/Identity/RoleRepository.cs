using Net.Core.Repositories.Core;
using System.Linq;
using System.Threading.Tasks;
using Net.Core.IRepositories.Identity;
using Net.Core.EntityModels.Identity;
using Microsoft.EntityFrameworkCore;

namespace Net.Core.Repositories.Identity
{
    public class RoleRepository : IdentityBaseRepository<Role>, IRoleRepository
    {
        //public RoleRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        public Role FindByName(string roleName)
        {
            return DbSet.FirstOrDefault(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return DbSet.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
