using Microsoft.AspNetCore.Mvc;
using N5.Application.Dtos;
using N5.Application.Interfaces;


namespace N5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<GetPermissionsDto>>> GetPermission()
        {
            var permissions = await _permissionService.GetPermissionsAsync();
            if (permissions == null || !permissions.Any())
                return NotFound("No permissions found.");

            return Ok(permissions);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionDto createDto)
        {
            var id = await _permissionService.CreateRequestPermissionAsync(createDto);
            return CreatedAtAction(nameof(GetPermission), new { id = id }, createDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPermission(int id, [FromBody] ModifyPermissionDto modifyDto)
        {
            modifyDto.Id = id;
            await _permissionService.ModifyPermissionAsync(modifyDto);
            return CreatedAtAction(nameof(GetPermission), new { id = id }, modifyDto);
        }
    }
}
