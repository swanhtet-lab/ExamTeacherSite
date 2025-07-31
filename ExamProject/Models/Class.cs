using System;
using System.Collections.Generic;

namespace ExamProject.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? Class1 { get; set; }

    public string? Year { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
