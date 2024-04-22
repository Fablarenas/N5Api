
using AutoMapper;
using N5.Domain.Entities;
using N5.Domain.Repositories;

namespace N5.Application.Commands.Handlers
{
    public class CreatePermissionCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePermissionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePermissionCommand command)
        {
            var permission = _mapper.Map<Permission>(command);
            IEntity<int> permissionEntity = await _unitOfWork.Permissions.AddPermissionAsync(permission);
            await _unitOfWork.CompleteAsync();
            permission.Id = permissionEntity.Item.Entity.Id;
            return permission.Id;
        }
    }
}
