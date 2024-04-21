namespace N5.Application.Dtos
{

    public class GetPermissionsDto
    {
            public int Id { get; set; }

            public string EmployeeForename { get; set; }

            public string EmployeeSurname { get; set; }

            public DateTime PermissionDate { get; set; }

            public virtual GetPermissionsType PermissionType { get; set; }

    }

    public class GetPermissionsType {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
