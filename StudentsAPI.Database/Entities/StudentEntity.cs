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

        public AddressEntity Address { get; set; }
    }
}
