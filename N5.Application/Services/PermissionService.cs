using N5.Application.Commands;
using N5.Application.Dtos;
using N5.Application.Commands.Handlers;
using N5.Application.Interfaces;
using AutoMapper;
using N5.Application.Handlers;

namespace N5.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly CreatePermissionCommandHandler _createPermissionHandler;
        private readonly GetAllPermissionsQueryHandler _getAllPermissionsHandler;
        private readonly ModifyPermissionCommandHandler _modifyPermissionCommandHandler;
        private readonly IMapper _mapper; 

        public PermissionService(CreatePermissionCommandHandler createHandler, IMapper mapper, GetAllPermissionsQueryHandler getAllPermissionsHandler, ModifyPermissionCommandHandler modifyPermissionCommandHandler)
        {
            _createPermissionHandler = createHandler;
            _mapper = mapper;
            _getAllPermissionsHandler = getAllPermissionsHandler;
            _modifyPermissionCommandHandler = modifyPermissionCommandHandler;
        }

        public async Task<int> CreateRequestPermissionAsync(CreatePermissionDto createDto)
        {
            var command = _mapper.Map<CreatePermissionCommand>(createDto);
            return await _createPermissionHandler.Handle(command);
        }

        public async Task<List<GetPermissionsDto>> GetPermissionsAsync()
        {
            return await _getAllPermissionsHandler.Handle();
        }

        public async Task<int> ModifyPermissionAsync(ModifyPermissionDto modifyDto)
        {
            var command = _mapper.Map<ModifyPermissionCommand>(modifyDto);
            return await _modifyPermissionCommandHandler.Handle(command);
        }
    }
}
