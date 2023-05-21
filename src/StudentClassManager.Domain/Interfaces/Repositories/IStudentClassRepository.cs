using StudentClassManager.Domain.Models;

namespace StudentClassManager.Domain.Interfaces.Repositories;

public interface IStudentClassRepository
{
    Task<IList<Student>> GetClassStudentsAsync(int classId);
    Task RemoveStudentFromClassAsync(int classId, int studentId);
    Task AssociateStudentWithClassAsync(int classId, int studentId);
}