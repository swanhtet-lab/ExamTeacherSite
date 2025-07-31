using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class ClassDto
    {
        public int ClassId { get; set; }

        public string? Class1 { get; set; }

        public string? Year { get; set; }

        public int? DepartmentId { get; set; }

        public virtual ICollection<DepartmentDto> Students { get; set; } = new List<DepartmentDto>();

        public virtual ICollection<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
    }
}
