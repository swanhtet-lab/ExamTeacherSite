using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }

        public string? Department1 { get; set; }

        public virtual ICollection<ClassDto> Classes { get; set; } = new List<ClassDto>();

        public virtual ICollection<TeacherDto> Teachers { get; set; } = new List<TeacherDto>();
    }
}

