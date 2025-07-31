using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class StudentDto
    {

        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public string? StudentRoll { get; set; }

        public string? StudentEmail { get; set; }

        public string? StudentPhone { get; set; }

        public string? StudentPassword { get; set; }

        public int? ClassId { get; set; }

        public virtual ICollection<StudentAnswerDto> StudentAnswers { get; set; } = new List<StudentAnswerDto>();
    }
}
