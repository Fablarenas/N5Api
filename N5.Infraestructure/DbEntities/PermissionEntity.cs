using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5.Infraestructure.DbEntities
{
    [Table("Permission")]
    public class PermissionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string EmployeeForename { get; set; }

        [Required]
        public string EmployeeSurname { get; set; }

        [Required]
        [ForeignKey("PermissionType")]
        public int PermissionTypeId { get; set; }

        public DateTime PermissionDate { get; set; }

        public virtual PermissionTypeEntity PermissionType { get; set; }

    }
}
