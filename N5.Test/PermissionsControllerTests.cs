using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using N5.Api.Controllers;
using N5.Application.Dtos;
using N5.Application.Interfaces;
using Xunit;

namespace N5.Test
{
    public class PermissionsControllerTests
    {
        private readonly Mock<IPermissionService> _mockService;
        private readonly Mock<ILogger<PermissionsController>> _mockLogger;
        private readonly PermissionsController _controller;

        public PermissionsControllerTests()
        {
            _mockService = new Mock<IPermissionService>();
            _mockLogger = new Mock<ILogger<PermissionsController>>();
            _controller = new PermissionsController(_mockService.Object, _mockLogger.Object);
        } 

        [Fact]
        public async Task GetPermission_ReturnsPermissions_WhenPermissionsExist()
        {
            // Arrange
            var permissions = new List<GetPermissionsDto>
            {
                new GetPermissionsDto
                {
                    Id = 1,
                    EmployeeSurname = "Fabian",
                    EmployeeForename = "Arenas",
                    PermissionDate = DateTime.Now,
                    PermissionType = new GetPermissionsType
                    {
                        Id = 1,
                        Description = "Vacaciones"
                    }
                }
            };

            _mockService.Setup(service => service.GetPermissionsAsync()).ReturnsAsync(permissions);
            var _controller = new PermissionsController(_mockService.Object, _mockLogger.Object);

            // Act
            var actionResult = await _controller.GetPermission();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedPermissions = Assert.IsType<List<GetPermissionsDto>>(okResult.Value);
            Assert.Single(returnedPermissions);
            Assert.Equal(permissions.First(), returnedPermissions.First());
        }


        [Fact]
        public async Task GetPermission_ReturnsNotFound_WhenNoPermissionsExist()
        {
            // Arrange
            _mockService.Setup(service => service.GetPermissionsAsync()).ReturnsAsync(new List<GetPermissionsDto>());

            // Act
            var result = await _controller.GetPermission();

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task CreatePermission_ReturnsCreatedAtAction_WhenCreated()
        {
            // Arrange
            var newDto = new CreatePermissionDto { EmployeeForename = "testCreacion", EmployeeSurname = "testCreacion", PermissionDate = DateTime.Now, PermissionTypeId = 1 };
            _mockService.Setup(service => service.CreateRequestPermissionAsync(newDto)).ReturnsAsync(1);

            // Act
            var result = await _controller.CreatePermission(newDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetPermission", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task ModifyPermission_ReturnsCreatedAtAction_WhenModified()
        {
            // Arrange
            var modifyDto = new ModifyPermissionDto { EmployeeForename = "test" , EmployeeSurname = "test", PermissionDate = DateTime.Now , PermissionTypeId = 1 };
            int id = 1;
            _mockService.Setup(service => service.ModifyPermissionAsync(modifyDto)).ReturnsAsync(1);

            // Act
            var result = await _controller.ModifyPermission(id, modifyDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetPermission", createdAtActionResult.ActionName);
        }

    }

}
