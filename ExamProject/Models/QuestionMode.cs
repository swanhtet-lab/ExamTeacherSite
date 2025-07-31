using System;
using System.Collections.Generic;

namespace ExamProject.Models;

public partial class QuestionMode
{
    public int QuestionModeId { get; set; }

    public string? QuestionMode1 { get; set; }

    public string? GivenPoint { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    public virtual ICollection<TeachertQa> TeachertQas { get; set; } = new List<TeachertQa>();
}
