using System;
using System.Collections.Generic;

namespace ExamProject.Models;

public partial class StudentAnswer
{
    public int StudentAnswerId { get; set; }

    public string? StudentAnswer1 { get; set; }

    public string? Point { get; set; }

    public int? StudentId { get; set; }

    public int? TeacherQuestionAnswerId { get; set; }

    public int? QuestionModeId { get; set; }

    public virtual QuestionMode? QuestionMode { get; set; }

    public virtual Student? Student { get; set; }

    public virtual TeachertQa? TeacherQuestionAnswer { get; set; }
}
