using Net.Core.EntityModels.Identity;
using Net.Core.IRepositories.Identity;
using Net.Core.Repositories.Core;

namespace Net.Core.Repositories.Identity
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        //public RoleRepository(DataContext dataContext)
        //    : base(dataContext)
        //{
        //}

        //public Role FindByName(string roleName)
        //{
        //    return DbSet.FirstOrDefault(x => x.Name == roleName);
        //}

        //public Task<Role> FindByNameAsync(string roleName)
        //{
        //    return DbSet.FirstOrDefaultAsync(x => x.Name == roleName);
        //}

        //public Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        //{
        //    return DbSet.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        //}
    }
}
