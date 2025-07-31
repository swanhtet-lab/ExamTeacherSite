using ExamProject.Data;
using ExamProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using ExamProject.Dtos;
using AutoMapper;


namespace ExamProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly ExamProjectContext _context;
        private readonly IMapper _mapper;


        public TeacherController(ExamProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetTeacherDepartmentsWithSubjects()
        {
            var departments = await _context.Departments
                .Include(d => d.Classes)
                    .ThenInclude(c => c.Subjects)
                .ToListAsync();

            return Ok(departments);
        }

        [HttpGet]
        [Route("teacherlogin")]
        public async Task<IActionResult> GetTeacher()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return new OkObjectResult(teachers);
        }

        [HttpGet("{departmentName}")]
        public async Task<IActionResult> GetTeacherByDepartment(string departmentName)
        {
            var department = await _context.Departments
                .Include(d => d.Teachers)
                .Include(d => d.Classes)
                    .ThenInclude(c => c.Subjects)           
                .FirstOrDefaultAsync(d => d.Department1 == departmentName);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        

        [HttpPost]
        public async Task<IActionResult> Teacher([FromBody] TeacherDto teacherDto)
        {

            var teachers = _mapper.Map<Teacher>(teacherDto);
            _context.Teachers.Add(teachers);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeacherDepartmentsWithSubjects), new { id = teachers.TeacherId }, teachers);

        }

    }
}