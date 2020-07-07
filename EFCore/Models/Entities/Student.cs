using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        // one-to-many
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        // one-to-one
        public StudentAddress Address { get; set; }
        // many-to-many
        public IList<StudentCourse> StudentCourses { get; set; }

        
    }
}
