using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class TeacherQaDto
    {
        public int TeacherQuestionAnswerId { get; set; }

        public string? Question { get; set; }

        public string? Answer { get; set; }

        public int? SubjectId { get; set; }

        public int? QuestionModeId { get; set; }

        public virtual ICollection<StudentAnswerDto> StudentAnswers { get; set; } = new List<StudentAnswerDto>();

       


    }
}
