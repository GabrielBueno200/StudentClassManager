using StudentClassManager.Domain.Models;

namespace StudentClassManager.Domain.Interfaces.Repositories;

public interface IClassRepository
{
    Task<Class> CreateAsync(Class classToCreate);
    Task<Class> GetClassByIdAsync(int classId);
    Task<Class> GetClassByNameAsync(string className);
    Task<List<Class>> GetAllClassesAsync();
    Task UpdateClassAsync(Class updatedClass);
    Task InactivateClassAsync(int classId);
}