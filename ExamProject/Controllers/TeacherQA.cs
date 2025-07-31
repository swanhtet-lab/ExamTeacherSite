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
    public class TeacherQA : ControllerBase
    {
        private readonly ExamProjectContext _context;
        private readonly IMapper _mapper;

        public TeacherQA(ExamProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacherQA()
        {
            var teacherQA = await _context.TeachertQas
                
                .ToListAsync();

            return Ok(teacherQA);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherQAById(int id)
        {
            var teacherQA = await _context.TeachertQas.FindAsync(id);
            if (teacherQA == null)
                return NotFound();
            return Ok(teacherQA);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTeacherQA([FromBody] TeacherQaDto teacherQaDto)
        {
            var teacherQA = _mapper.Map<TeachertQa>(teacherQaDto);
            _context.TeachertQas.Add(teacherQA);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacherQA), new { id = teacherQA.TeacherQuestionAnswerId }, teacherQA);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacherQA(int id, [FromBody] TeacherQaDto teacherQaDto)
        {
            var existingTeacherQA = await _context.TeachertQas.FindAsync(id);
            if (existingTeacherQA == null)
                return NotFound();

            _mapper.Map(teacherQaDto, existingTeacherQA);
            await _context.SaveChangesAsync();

            return Ok(existingTeacherQA);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherQA(int id)
        {
            var teacherQA = await _context.TeachertQas.FindAsync(id);
            if (teacherQA == null)
                return NotFound();

            _context.TeachertQas.Remove(teacherQA);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
