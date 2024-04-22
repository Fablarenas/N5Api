namespace N5.Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string EmployeeForename { get; private set; }
        public string EmployeeSurname { get; private set; }
        public DateTime PermissionDate { get; private set; } = DateTime.Now;
        public int? PermissionTypeId { get; private set; }
        public virtual PermissionType PermissionType { get; private set; }
        protected Permission() { }

        public Permission(string employeeForename, string employeeSurname, DateTime permissionDate, PermissionType permissionType)
        {
            EmployeeForename = employeeForename ?? throw new ArgumentNullException(nameof(employeeForename));
            EmployeeSurname = employeeSurname ?? throw new ArgumentNullException(nameof(employeeSurname));
            PermissionDate = permissionDate;
            PermissionType = permissionType;
        }

    }
}