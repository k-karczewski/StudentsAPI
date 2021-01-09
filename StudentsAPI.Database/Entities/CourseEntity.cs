using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<StudentCourseEntity> StudentCourses { get; set; }
    }
}
