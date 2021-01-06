using Microsoft.EntityFrameworkCore;
using StudentsAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Context
{
    public class StudentsAPIDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }

        public StudentsAPIDbContext(DbContextOptions options) : base(options) { }
    }
}
