using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N5.Domain.Entities;
using N5.Domain.Repositories;
using N5.Infraestructure.DataContext;
using N5.Infraestructure.DbEntities;

namespace N5.Infrastructure.Repositories
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly N5DbContext _context;
        private readonly IMapper _mapper;

        public PermissionTypeRepository(N5DbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PermissionType> GetPermissionTypeByIdAsync(int id)
        {
            var permissionEntity = await _context.PermissionTypes.FindAsync(id);
            return _mapper.Map<PermissionType>(permissionEntity);
        }

        public async Task<IEnumerable<PermissionType>> GetAllPermissionTypesAsync()
        {
            var permissionsEntity = await _context.PermissionTypes.ToListAsync();
            return _mapper.Map<List<PermissionType>>(permissionsEntity);
        }

        public async Task AddPermissionTypeAsync(PermissionType permission)
        {
            var permissionEntity = _mapper.Map<PermissionTypeEntity>(permission);
            await _context.PermissionTypes.AddAsync(permissionEntity);
        }

        public async Task UpdatePermissionTypeAsync(PermissionType permission)
        {
            var permissionEntity = _mapper.Map<PermissionTypeEntity>(permission);
            _context.PermissionTypes.Update(permissionEntity);
        }
    }
}