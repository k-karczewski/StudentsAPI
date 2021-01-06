using Microsoft.EntityFrameworkCore;
using StudentsAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Context
{
    public class StudentsApiDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }

        public StudentsApiDbContext(DbContextOptions options) : base(options) { }
    }
}
