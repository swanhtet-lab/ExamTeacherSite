using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class QuestionModeDto
    {
        public int QuestionModeId { get; set; }

        public string? QuestionMode1 { get; set; }

        public string? GivenPoint { get; set; }

        public virtual ICollection<StudentAnswerDto> StudentAnswers { get; set; } = new List<StudentAnswerDto>();

        public virtual ICollection<TeacherQaDto> TeachertQas { get; set; } = new List<TeacherQaDto>();
    }
}
