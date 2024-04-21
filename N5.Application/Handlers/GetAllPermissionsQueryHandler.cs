// N5.Application/Handlers/GetAllPermissionsQueryHandler.cs

using N5.Domain.Repositories;
using N5.Application.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5.Application.Handlers
{
    public class GetAllPermissionsQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetPermissionsDto>> Handle()
        {
            var permissions = await _unitOfWork.Permissions.GetAllPermissionsAsync();
            return _mapper.Map<List<GetPermissionsDto>>(permissions);
        }
    }
}
