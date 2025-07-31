using ExamProject.Models;

namespace ExamProject.Dtos
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }

        public string? TeacherName { get; set; }

        public string? TeacherEmail { get; set; }

        public string? TeacherPhone { get; set; }

        public string? Position { get; set; }

        public string? TeacherPassword { get; set; }

        public int? DepartmentId { get; set; }

        
    }
}
