using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Entities
{
    public class GradeEntity
    {
        public int Id { get; set; }
        public string GradeName { get; set; }

        public virtual List<StudentEntity> Students { get; set; }
    }
}
