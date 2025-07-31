using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class StudentAnswerDto
    {
        public int StudentAnswerId { get; set; }

        public string? StudentAnswer1 { get; set; }

        public string? Point { get; set; }

        public int? StudentId { get; set; }

        public int? TeacherQuestionAnswerId { get; set; }

        public int? QuestionModeId { get; set; }

        
    }
}
