using N5.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Application.Interfaces
{
    public interface IPermissionService
    {
        public Task<List<GetPermissionsDto>> GetPermissionsAsync();
        public Task<int> CreateRequestPermissionAsync(CreatePermissionDto createDto);
        public Task<int> ModifyPermissionAsync(ModifyPermissionDto modifyDto);
        public Task<GetPermissionsDto> GetPermissionByIdAsync(int id);
    }
}
