using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models;
using StudentManagement.API.Services;

namespace StudentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService, Logger<StudentsController> logger)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Fetching student with Id {Id}", id);
            var student = _studentService.GetById(id);

            if (student == null)
            {

                _logger.LogWarning("Student with Id {Id} not found", id);
                return NotFound($"Student with Id {id} not found.");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            var createdStudent = _studentService.Add(student);
            return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
        }
    }
}