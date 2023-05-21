using System.ComponentModel.DataAnnotations.Schema;

namespace StudentClassManager.Domain.Common;

public abstract class BaseEntity
{
    [Column("id")]
    public int Id { get; set; }
}
