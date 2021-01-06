using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Entities
{
    public class GradeEntity
    {
        public int Id { get; set; }
        public string GradeValue { get; set; }
        public string Subject { get; set; }

        public int StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
    }
}
