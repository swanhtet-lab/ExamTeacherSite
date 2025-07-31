using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamProject.Data;
using ExamProject.Dtos;
using AutoMapper;
using ExamProject.Models;
namespace ExamProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ExamProjectContext _context;

        private readonly IMapper _mapper;

        public DepartmentController(ExamProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            var departments = await _context.Departments
                .Include(d => d.Teachers)
                .Include(d => d.Classes)               
                    .ThenInclude(c => c.Subjects)      
                .ToListAsync();

            return Ok(departments);
        }

        [HttpGet("dept/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Teachers)
                .Include(d => d.Classes)
                    .ThenInclude(c => c.Subjects)
                .FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (department == null)
                return NotFound();

            return Ok(department);
        }


        [HttpGet("{departmentName}")]
        public async Task<IActionResult> GetDepartmentByName(string departmentName)
        {
            var department = await _context.Departments.
                Include(d => d.Teachers)
                .Include(d => d.Classes)
                    .ThenInclude(c => c.Subjects)
                .FirstOrDefaultAsync(d => d.Department1 == departmentName);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        


        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentdto)
        {

            var department = _mapper.Map<Department>(departmentdto);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartment), new { id = department.DepartmentId }, department);

        }
    }
}
