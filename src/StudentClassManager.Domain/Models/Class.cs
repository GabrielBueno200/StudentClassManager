using StudentClassManager.Domain.Common;

namespace StudentClassManager.Domain.Models;

public class Class : BaseEntity
{
    public string? ClassName { get; set; }
    public int Year { get; set; }
    public int CourseId { get; set; }
}
