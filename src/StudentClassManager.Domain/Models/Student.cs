using System.ComponentModel.DataAnnotations.Schema;
using StudentClassManager.Domain.Common;

namespace StudentClassManager.Domain.Models;

[Table("aluno")]
public class Student : BaseEntity
{
    [Column("nome")]
    public string? Name { get; set; }
    [Column("usuario")]
    public string? UserName { get; set; }
    [Column("senha")]
    public string? Password { get; set; }
}
