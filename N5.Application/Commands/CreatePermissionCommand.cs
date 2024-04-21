// N5.Application/Commands/CreatePermissionCommand.cs

namespace N5.Application.Commands
{
    public class CreatePermissionCommand
    {
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
