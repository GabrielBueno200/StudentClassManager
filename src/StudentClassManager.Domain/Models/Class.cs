using System.ComponentModel.DataAnnotations.Schema;
using StudentClassManager.Domain.Common;

namespace StudentClassManager.Domain.Models;

[Table("turma")]
public class Class : BaseEntity
{
    [Column("turma")]
    public string? ClassName { get; set; }
    [Column("ano")]
    public int Year { get; set; }
    [Column("curso_id")]
    public int CourseId { get; set; }
}
