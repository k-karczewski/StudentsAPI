﻿using Microsoft.EntityFrameworkCore;
using StudentsAPI.Database.Entities;

namespace StudentsAPI.Database.Context
{
    public class StudentsApiDbContext : DbContext
    {
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }
    
        public StudentsApiDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEntity>(student =>
            {
                student.HasKey(k => k.Id);
                student.HasOne(a => a.Address).WithOne(s => s.Student).HasForeignKey<AddressEntity>(a => a.StudentId).OnDelete(DeleteBehavior.Cascade);
                student.Property(p => p.FirstName).IsRequired();
                student.Property(p => p.LastName).IsRequired();
                student.Property(p => p.LastName).IsRequired();

                student.HasOne(g => g.Grade).WithMany(s => s.Students).HasForeignKey(k => k.GradeId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AddressEntity>(address =>
            {
                address.HasKey(k => k.Id);
                address.Property(p => p.Street).IsRequired();
                address.Property(p => p.City).IsRequired();
                address.Property(p => p.Country).IsRequired();
            });

            modelBuilder.Entity<StudentCourseEntity>(entity =>
            {
                entity.HasKey(k => new { k.StudentId, k.CourseId });
                entity.HasOne(s => s.Student).WithMany(sc => sc.StudentCourses).HasForeignKey(k => k.StudentId);
                entity.HasOne(c => c.Course).WithMany(sc => sc.StudentCourses).HasForeignKey(k => k.CourseId);
            });
        }
    }
}
