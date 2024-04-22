namespace N5.Infraestructure.ElasticEntities
{
    public class PermissionDocument
    {
        public int Id { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public PermissionTypeDocument PermissionTypeDocument { get; set; }
        public DateTime PermissionDate { get; set; }
    }

    public class PermissionTypeDocument
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
