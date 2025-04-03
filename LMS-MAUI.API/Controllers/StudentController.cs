using Microsoft.AspNetCore.Mvc;
using System;
using LearningManagementSystem;

namespace LMS_MAUI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentServices _studentServices;
        public StudentController() {
            _studentServices = StudentServices.Current;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var student = _studentServices.Students;
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id) 
        {
            var student = _studentServices.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddPerson(Student student)
        {
            _studentServices.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.studentId }, student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id, Student student)
        {
            if (student == null)
                return NotFound();

            _studentServices.Remove(student);
            return NoContent();
        }

        [HttpPost("create")]
        public IActionResult CreatePerson(Student student)
        {
            _studentServices.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.studentId }, student);
        }
    }
}
