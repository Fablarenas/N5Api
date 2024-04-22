using AutoMapper;
using N5.Application.Dtos;
using N5.Application.Queries;
using N5.Domain.Entities;
using N5.Domain.Repositories;

namespace N5.Application.Handlers
{
    public class GetPermissionTypeByIdHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPermissionTypeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PermissionType> Handle(GetPermissionTypeByIdQuery query)
        {
            return await _unitOfWork.PermissionTypes.GetPermissionTypeByIdAsync(query.PermissionTypeId);
        }
    }
}
