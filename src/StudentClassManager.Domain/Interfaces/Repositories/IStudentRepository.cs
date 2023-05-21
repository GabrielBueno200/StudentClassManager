using StudentClassManager.Domain.Models;

namespace StudentClassManager.Domain.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student studentToCreate);
    Task<Student> GetStudentByIdAsync(int studentId);
    Task<List<Student>> GetAllStudentsAsync();
    Task UpdateStudentAsync(Student updatedStudent);
    Task ActivateStudentAsync(int studentId, bool isActive);
}
