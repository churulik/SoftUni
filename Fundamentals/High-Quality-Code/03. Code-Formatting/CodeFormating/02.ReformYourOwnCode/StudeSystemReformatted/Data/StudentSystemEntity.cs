using StudentSystem.Models;
using _02.ReformYourOwnCode.StudeSystemReformatted.Models;

namespace _02.ReformYourOwnCode.StudeSystemReformatted.Data
{
    public class StudentSystemEntity : DbContext
    {
        public StudentSystemEntity()
            : base("name=StudentSystemEntity")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemEntity, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<ResourceLicenses> ResourceLicenseses { get; set; }
    }
}