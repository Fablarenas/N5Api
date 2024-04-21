using N5.Domain.Entities;
namespace N5.Domain.Repositories
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();
        Task AddPermissionAsync(Permission permission);
        Task UpdatePermissionAsync(Permission permission);
    }
}
