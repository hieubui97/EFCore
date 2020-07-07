using EFCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models.Configurations
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("StudentCourse");

            builder.HasKey(x => new { x.StudentId, x.CourseId });

            builder.HasOne(x => x.Course).WithMany(x => x.StudentCourses).HasForeignKey(x => x.CourseId);

            builder.HasOne(x => x.Student).WithMany(x => x.StudentCourses).HasForeignKey(x => x.StudentId);
        }
    }
}
