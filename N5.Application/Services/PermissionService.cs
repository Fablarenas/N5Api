using N5.Application.Commands;
using N5.Application.Dtos;
using N5.Application.Commands.Handlers;
using N5.Application.Interfaces;
using AutoMapper;
using N5.Application.Handlers;
using N5.Application.Queries;
using N5.Domain.Repositories;
using N5.Domain.Entities;

namespace N5.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly CreatePermissionCommandHandler _createPermissionHandler;
        private readonly GetAllPermissionsQueryHandler _getAllPermissionsHandler;
        private readonly ModifyPermissionCommandHandler _modifyPermissionCommandHandler;
        private readonly GetPermissionTypeByIdHandler _getPermissionTypeByIdHandler;
        private readonly GetPermissionByIdQueryHandler _getPermissionByIdHandler;
        private readonly IMapper _mapper; 
        private readonly INotificationPermission _notificationPermission;

        public PermissionService(CreatePermissionCommandHandler createHandler, IMapper mapper, GetAllPermissionsQueryHandler getAllPermissionsHandler, ModifyPermissionCommandHandler modifyPermissionCommandHandler, GetPermissionTypeByIdHandler getPermissionByIdHandler, INotificationPermission notificationPermission, GetPermissionByIdQueryHandler getPermissionByIdQueryHandler )
        {
            _createPermissionHandler = createHandler;
            _mapper = mapper;
            _getAllPermissionsHandler = getAllPermissionsHandler;
            _modifyPermissionCommandHandler = modifyPermissionCommandHandler;
            _getPermissionTypeByIdHandler = getPermissionByIdHandler;
            _notificationPermission = notificationPermission;
            _getPermissionByIdHandler = getPermissionByIdQueryHandler;

        }

        public async Task<int> CreateRequestPermissionAsync(CreatePermissionDto createDto)
        {
            var query = _mapper.Map<GetPermissionTypeByIdQuery>(createDto);
            var permissionType = await _getPermissionTypeByIdHandler.Handle(query);
            if (permissionType == null)
                throw new Exception("No existe el tipo de permiso");

            var command = _mapper.Map<CreatePermissionCommand>(createDto);

            command.PermissionTypeId = permissionType.Id;
            command.PermissionTypeDescription = permissionType.Description;

            var idPermissionCreated = await _createPermissionHandler.Handle(command);
            var permissionNotification = _mapper.Map<Permission>(command);
            permissionNotification.Id = idPermissionCreated;
            await _notificationPermission.NotificateAddPermissionAsync(permissionNotification);
            return idPermissionCreated;
        }

        public async Task<List<GetPermissionsDto>> GetPermissionsAsync()
        {
            return await _getAllPermissionsHandler.Handle();
        }

        public async Task<GetPermissionsDto> GetPermissionByIdAsync(int id)
        {
            var permissiontDomain = await _getPermissionByIdHandler.Handle(new Querys.GetPermissionByIdQuery{ PermissionId = id });
            var permission = _mapper.Map<GetPermissionsDto>(permissiontDomain);
            return permission;
        }

        public async Task<int> ModifyPermissionAsync(ModifyPermissionDto modifyDto)
        {
            var command = _mapper.Map<ModifyPermissionCommand>(modifyDto);
            var id = await _modifyPermissionCommandHandler.Handle(command);
            var permissionNotification = _mapper.Map<Permission>(command);
            await _notificationPermission.NotificateAddPermissionAsync(permissionNotification);
            return id;
        }
    }
}
