using N5.Domain.Entities;
using System.Security.Principal;
namespace N5.Domain.Repositories
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task<IEntity<int>> AddPermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
    }
}
