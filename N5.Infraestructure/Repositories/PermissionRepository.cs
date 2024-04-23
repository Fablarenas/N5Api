using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N5.Domain.Entities;
using N5.Domain.Repositories;
using N5.Infraestructure.DataContext;
using N5.Infraestructure.DbEntities;

namespace N5.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly N5DbContext _context;
        private readonly IMapper _mapper;

        public PermissionRepository(N5DbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            var permissionEntity = await _context.Permissions.FindAsync(id);
            return _mapper.Map<Permission>(permissionEntity);
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            var permissionsEntity = await _context.Permissions.Include(p => p.PermissionType).ToListAsync();
            return _mapper.Map<List<Permission>>(permissionsEntity);
        }

        public async Task<IEntity<int>> AddPermissionAsync(Permission permission)
        {
            var permissionEntity = _mapper.Map<PermissionEntity>(permission);
            var insertedPermission = await _context.Permissions.AddAsync(permissionEntity);
            return new Entity<int>(insertedPermission, nameof(permissionEntity.Id));
        }

        public async Task UpdatePermissionAsync(Permission permission)
        {
            var permissionEntity = _mapper.Map<PermissionEntity>(permission);
            _context.Permissions.Update(permissionEntity);
        }
    }
}