using N5.Domain.Entities;
namespace N5.Domain.Repositories
{
    public interface IPermissionTypeRepository
    {
        Task<PermissionType> GetPermissionTypeByIdAsync(int id);
        Task<IEnumerable<PermissionType>> GetAllPermissionTypesAsync();
        Task AddPermissionTypeAsync(PermissionType permission);
        Task UpdatePermissionTypeAsync(PermissionType permission);
    }
}
