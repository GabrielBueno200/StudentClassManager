namespace StudentClassManager.Application.ViewModels;

public class StudentClassViewModel
{
    public int StudentId { get; set; }
    public int ClassId { get; set; }
    public virtual StudentViewModel? Student { get; set; }
    public virtual ClassViewModel? Class { get; set; }
}