using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentViewModel>> FindAllStudentsAsync();
    Task<StudentViewModel> CreateStudentAsync(StudentViewModel student);
    Task<StudentViewModel> GetStudentByIdAsync(int id);
    Task UpdateStudentAsync(StudentViewModel student);
    Task DeleteStudentAsync(int studentId);
}
