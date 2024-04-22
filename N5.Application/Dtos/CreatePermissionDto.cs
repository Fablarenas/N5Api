
using System.Text.Json.Serialization;

namespace N5.Application.Dtos
{
    public class CreatePermissionDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        [JsonIgnore]
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
