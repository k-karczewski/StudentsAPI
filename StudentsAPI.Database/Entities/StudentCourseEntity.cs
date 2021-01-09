using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Entities
{
    public class StudentCourseEntity
    {
        public int StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }

        public int CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
    }
}
