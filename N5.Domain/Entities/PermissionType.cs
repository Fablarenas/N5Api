namespace N5.Domain.Entities
{
    public class PermissionType
    {
        public int Id { get; protected set; }
        public string Description { get; private set; }

        public virtual ICollection<Permission> Permissions { get; private set; }

        protected PermissionType()
        {
            Permissions = new HashSet<Permission>();
        }

        public PermissionType(string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Permissions = new HashSet<Permission>();
        }
    }
}
