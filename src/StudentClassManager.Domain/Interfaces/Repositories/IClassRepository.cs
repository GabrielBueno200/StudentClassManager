using StudentClassManager.Domain.Models;

namespace StudentClassManager.Domain.Interfaces.Repositories;

public interface IClassRepository
{
    Task<Class> CreateAsync(Class classToCreate);
    Task<Class> GetClassById(int classId);
    Task<List<Class>> GetAllClasses();
    Task UpdateClass(Class updatedClass);
    Task ActivateClass(bool isActive);
}