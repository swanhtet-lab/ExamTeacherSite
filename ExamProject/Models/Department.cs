using System;
using System.Collections.Generic;

namespace ExamProject.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? Department1 { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
