
using Microsoft.EntityFrameworkCore;
using N5.Infraestructure.DbEntities;

namespace N5.Infraestructure.DataContext
{
    public class N5DbContext : DbContext 
    {
        public N5DbContext(DbContextOptions<N5DbContext> options):base(options)
        {
            
        }

        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<PermissionTypeEntity> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
