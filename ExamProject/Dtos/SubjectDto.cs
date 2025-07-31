using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }

        public string? Subject1 { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public byte[]? AvailableTime { get; set; }
        public string? Availability { get; set; }
        public int? ClassId { get; set; }
        public virtual ICollection<TeacherQaDto> TeachertQas { get; set; } = new List<TeacherQaDto>();
    }
}
