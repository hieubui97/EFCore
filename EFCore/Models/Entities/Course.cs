using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        // many-to-many
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
