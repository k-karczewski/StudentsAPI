using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int IndexNumber { get; set; }

        public virtual AddressEntity Address { get; set; }

        public int GradeId { get; set; }
        public virtual GradeEntity Grade { get; set; }

        public virtual List<StudentCourseEntity> StudentCourses { get; set; }
    }
}
