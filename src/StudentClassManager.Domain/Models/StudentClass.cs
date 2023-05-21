using StudentClassManager.Domain.Common;

namespace StudentClassManager.Domain.Models;

public class StudentClass : BaseEntity
{
    public int StudentId { get; set; }
    public int ClassId { get; set; }
    public virtual Student? Student { get; set; }
    public virtual Class? Class { get; set; }
}
