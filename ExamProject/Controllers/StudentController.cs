using AutoMapper;
using ExamProject.Data;
using ExamProject.Dtos;
using ExamProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ExamProjectContext _context;
        private readonly IMapper _mapper;


        public StudentController(ExamProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return new OkObjectResult(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] DepartmentDto studentDto)
        {
            
            var student = _mapper.Map<Student>(studentDto);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudents), new { id = student.StudentId }, student);

        }
        
        
    }
}
