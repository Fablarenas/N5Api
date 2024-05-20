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
        private readonly ILogger<PermissionsController> _logger;

        public PermissionsController(IPermissionService permissionService, ILogger<PermissionsController> logger)
        {
            _permissionService = permissionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPermissionsDto>>> GetPermission()
        {
            _logger.LogInformation("Called Get() GetPermission");
            var permissions = await _permissionService.GetPermissionsAsync();

            if (permissions == null || permissions.Count == 0)
            {
                _logger.LogInformation("NotFound Get() GetPermission");
                return NotFound("No permissions found.");
            }

            _logger.LogInformation("Ok Get() GetPermission");
            return Ok(permissions);
        }

        [HttpGet("id")]
        public async Task<ActionResult<GetPermissionsDto>> GetPermissionById([FromQuery] int id)
        {
            _logger.LogInformation("Called Get() GetPermission");
            var permissions = await _permissionService.GetPermissionByIdAsync(id);

            if (permissions == null)
            {
                _logger.LogInformation("NotFound Get() GetPermission");
                return NotFound("No permissions found.");
            }

            _logger.LogInformation("Ok Get() GetPermission");
            return Ok(permissions);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionDto createDto)
        {
            _logger.LogInformation("Called Post() CreatePermission");
            var id = await _permissionService.CreateRequestPermissionAsync(createDto);
            _logger.LogInformation("Called Ok() CreatePermission");
            return CreatedAtAction(nameof(GetPermission), new { id = id }, createDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPermission(int id, [FromBody] ModifyPermissionDto modifyDto)
        {
            _logger.LogInformation("Called Put() ModifyPermission");
            modifyDto.Id = id;
            await _permissionService.ModifyPermissionAsync(modifyDto);
            _logger.LogInformation("Called Ok() ModifyPermission");
            return CreatedAtAction(nameof(GetPermission), new { id = id }, modifyDto);
        }
    }
}
