using EFCore.Models.Configurations;
using EFCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EFCore.Models.EFCore
{
    public class SchoolDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=VTP-CUPH;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure using Fluent API
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

            // Shadow property
            modelBuilder.Entity<Student>().Property<DateTime>("CreateDate");
            modelBuilder.Entity<Student>().Property<DateTime>("UpdateDate");
        }


        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker
        //    .Entries()
        //    .Where(e =>
        //    e.State == EntityState.Added
        //    || e.State == EntityState.Modified);

        //    foreach (var entityEntry in entries)
        //    {
        //        entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

        //        if (entityEntry.State == EntityState.Added)
        //        {
        //            entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
        //        }
        //    }

        //    return base.SaveChanges();
        //}

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
