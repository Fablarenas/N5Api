using Microsoft.EntityFrameworkCore;
using N5.Domain.Repositories;
using N5.Infraestructure.DataContext;

namespace N5.Infrastructure.Repositories.UnitWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly N5DbContext _context;
        public IPermissionRepository Permissions { get; }
        public IPermissionTypeRepository PermissionTypes { get; }

        public UnitOfWork(N5DbContext context, IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Permissions = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            PermissionTypes = permissionTypeRepository ?? throw new ArgumentNullException(nameof(permissionTypeRepository));
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
