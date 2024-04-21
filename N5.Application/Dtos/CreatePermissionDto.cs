
namespace N5.Application.Dtos
{
    public class CreatePermissionDto
    {
        public int Id { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }
        public string PermissionTypeName { get; set; }
    }
}
