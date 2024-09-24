using Entity.TableModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog=Restoran_DB;Integrated Security = True; Encrypt = False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var createdDateProperty = entityType.FindProperty("CreatedDate");

                if (createdDateProperty is not null)
                    createdDateProperty.SetDefaultValueSql("getdate()");
            }
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutPhoto> AboutPhotos { get; set; }
    }
}
