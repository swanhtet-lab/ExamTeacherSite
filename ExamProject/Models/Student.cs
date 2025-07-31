using System;
using System.Collections.Generic;

namespace ExamProject.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentRoll { get; set; }

    public string? StudentEmail { get; set; }

    public string? StudentPhone { get; set; }

    public string? StudentPassword { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
}
