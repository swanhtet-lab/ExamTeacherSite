using System;
using System.Collections.Generic;

namespace ExamProject.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? Subject1 { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public byte[]? AvailableTime { get; set; }

    public string? Availability { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<TeachertQa> TeachertQas { get; set; } = new List<TeachertQa>();
}
