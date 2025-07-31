using System;
using System.Collections.Generic;

namespace ExamProject.Models;

public partial class TeachertQa
{
    public int TeacherQuestionAnswerId { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public int? SubjectId { get; set; }

    public int? QuestionModeId { get; set; }

    public virtual QuestionMode? QuestionMode { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    public virtual Subject? Subject { get; set; }
}
