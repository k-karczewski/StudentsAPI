using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
    }
}
