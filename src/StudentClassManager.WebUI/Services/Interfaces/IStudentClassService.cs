using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Services.Interfaces;

public interface IStudentClassService
{
    Task<IList<StudentViewModel>> GetClassStudentsAsync(int classId);
    Task AssociateStudentWithClassAsync(int studentId, int classId);
    Task<IList<StudentViewModel>> GetStudentsToAssociate(int classId);
    Task RemoveStudentFromClassAsync(int studentId, int classId);
}