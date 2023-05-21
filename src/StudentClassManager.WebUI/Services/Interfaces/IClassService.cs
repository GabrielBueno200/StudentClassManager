using StudentClassManager.WebUI.ViewModels;

namespace StudentClassManager.WebUI.Services.Interfaces;

public interface IClassService
{
    Task<IList<ClassViewModel>> FindAllClassesAsync();
    Task<ClassViewModel> CreateClassAsync(ClassViewModel classToCreate);
    Task<ClassViewModel> GetClassByIdAsync(int id);
    Task UpdateClassAsync(ClassViewModel classToUpdate);
    Task DeleteClassAsync(int classId);
}