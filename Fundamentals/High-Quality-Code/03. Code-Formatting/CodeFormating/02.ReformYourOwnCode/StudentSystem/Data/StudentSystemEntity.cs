using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

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
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<ResourceLicenses> ResourceLicenseses { get; set; }
    }
}