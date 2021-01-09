using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentsAPI.Database.Context;
using StudentsAPI.Database.Entities;
using StudentsAPI.Database.Repositories.Base;
using StudentsAPI.Database.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StudentsAPI.Database.Repositories
{
    public class StudentsRepository : BaseRepository<StudentEntity>, IStudentsRepository
    {
        protected override DbSet<StudentEntity> DbSet => Context.Students;

        public StudentsRepository(StudentsApiDbContext context) : base(context) { }

       
        public List<StudentEntity> GetAll()
        {
            List<StudentEntity> students = DbSet.Include(a => a.Address)
                                                .Include(g => g.Grade)
                                                .Include(sc => sc.StudentCourses).ThenInclude(c => c.Course)
                                                .ToList();
            return students;
        }

        public StudentEntity GetById(int studentId)
        {
            StudentEntity student = DbSet.Include(a => a.Address)
                                         .Include(g => g.Grade)
                                         .Include(sc => sc.StudentCourses).ThenInclude(c => c.Course)
                                         .FirstOrDefault(x => x.Id == studentId);
            return student;
        }

        public StudentEntity Create(StudentEntity student)
        {
            EntityEntry<StudentEntity> newStudent = DbSet.Add(student);
            return newStudent.Entity;
        }

        public void Delete(int studentId)
        {
            StudentEntity student = DbSet.FirstOrDefault(x => x.Id == studentId);
            
            if(student != null)
            {
                DbSet.Remove(student);
            }
        }

        public void Update(StudentEntity newStudent, int studentId)
        {
            StudentEntity student = DbSet.Include(a => a.Address).Include(g => g.Grade).FirstOrDefault(x => x.Id == studentId);

            if (student != null)
            {
                student.FirstName = newStudent.FirstName;
                student.LastName = newStudent.LastName;
                student.Age = newStudent.Age;
                student.IndexNumber = newStudent.IndexNumber;

                if (newStudent.Address != null)
                {
                    student.Address = newStudent.Address;
                }
                
                if (newStudent.Grade != null)
                {
                    student.Grade = newStudent.Grade;
                }
            }
        }

        public void AssignCourse(int studentId, int courseId)
        {
            StudentEntity student = DbSet.Include(sc => sc.StudentCourses).FirstOrDefault(x => x.Id == studentId);
            bool courseExists = Context.Courses.FirstOrDefault(x => x.Id == courseId) != null ? true : false;

            if(courseExists && student != null)
            {
                student.StudentCourses.Add(new StudentCourseEntity
                {
                    StudentId = studentId,
                    CourseId = courseId
                });
            }
        }

        public void DeassignCourse(int studentId, int courseId)
        {
            StudentEntity student = DbSet.Include(sc => sc.StudentCourses).FirstOrDefault(x => x.Id == studentId);
            
            if(student != null)
            {
                StudentCourseEntity studentCourse = student.StudentCourses.FirstOrDefault(c => c.CourseId == courseId);

                if(studentCourse != null)
                {
                    student.StudentCourses.Remove(studentCourse);
                }
            }
        }
    }
}
