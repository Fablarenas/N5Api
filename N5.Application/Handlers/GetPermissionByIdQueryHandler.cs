using AutoMapper;
using N5.Application.Querys;
using N5.Domain.Entities;
using N5.Domain.Repositories;

namespace N5.Application.Handlers
{
    public class GetPermissionByIdQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPermissionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Permission> Handle(GetPermissionByIdQuery query)
        {
            var permissionEntity = await _unitOfWork.Permissions.GetPermissionByIdAsync(query.PermissionId);
            var permission = _mapper.Map<Permission>(permissionEntity);
            return permission;
        }
    }
}
