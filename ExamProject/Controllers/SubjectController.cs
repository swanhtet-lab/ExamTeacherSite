using AutoMapper;
using ExamProject.Data;
using ExamProject.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.Controllers { 
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ExamProjectContext _context;
        private readonly IMapper _mapper;

        public SubjectController(ExamProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();
            return Ok(subjects);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateSubjectStatus(int id, [FromBody] string status)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                return NotFound();

            subject.Status = status;
            await _context.SaveChangesAsync();

            return Ok(subject);
        }

    }
}
