using StudentsAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Repositories.Interfaces
{
    public interface IStudentsRepository
    {
        List<StudentEntity> GetAll();
        StudentEntity GetById(int studentId);
        void Create(StudentEntity student);
        void Delete(int studentId);
        void Update(StudentEntity newStudent, int studentId);
        void AssignCourse(int studentId, int courseId);
        void DeassignCourse(int studentId, int courseId);
        void SaveChanges();
    }
}
