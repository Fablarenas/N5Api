using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5.Infraestructure.DbEntities
{
    public class PermissionTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<PermissionEntity> Permissions { get; set; }

        public PermissionTypeEntity()
        {
            Permissions = new HashSet<PermissionEntity>();
        }
    }
}
