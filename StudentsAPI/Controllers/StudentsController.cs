using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Database.Entities;
using StudentsAPI.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace StudentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepo;

        public StudentsController(IStudentsRepository studentsRepo) 
        {
            _studentsRepo = studentsRepo;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<StudentEntity> students = _studentsRepo.GetAll();
            return Ok(students);
        }


        [HttpGet("{id}", Name ="GetById")]
        public IActionResult GetStudentById(int id)
        {
            StudentEntity student = _studentsRepo.GetById(id);
            return Ok(student);
        }

        [HttpPost("create")]
        public IActionResult CreateStudent(StudentEntity student)
        {
            Random randomGenerator = new Random();
            int indexNumber = randomGenerator.Next(10000, 99999);

            student.IndexNumber = indexNumber;

            StudentEntity newStudent = _studentsRepo.Create(student);
            _studentsRepo.SaveChanges();

            return CreatedAtRoute("GetById", new { newStudent.Id }, newStudent);
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateStudent(StudentEntity student, int id)
        {
             _studentsRepo.Update(student, id);
            _studentsRepo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentsRepo.Delete(id);
            _studentsRepo.SaveChanges();

            return Ok();
        }

    }
}
