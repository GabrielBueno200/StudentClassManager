using Dapper;
using StudentClassManager.Domain.Interfaces.Repositories;
using StudentClassManager.Domain.Models;
using StudentClassManager.Infrastructure.Persistence.UnitOfWork;

namespace StudentClassManager.Infrastructure.Persistence.Repositories;

public class ClassRepository : IClassRepository
{
    private readonly IUnitOfWork _uow;

    public ClassRepository(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Class> CreateAsync(Class classToCreate)
    {
        var parameters = new
        {
            ClassName = classToCreate.ClassName,
            Year = classToCreate.Year,
        };

        var result = await _uow.GetConnection().QueryFirstOrDefaultAsync<Class>(@"
            INSERT INTO turma (turma, ano)
            VALUES (@ClassName, @Year);

            SELECT * FROM turma WHERE id = SCOPE_IDENTITY();
        ", parameters);

        return result;
    }

    public async Task<List<Class>> GetAllClassesAsync()
    {
        var result = await _uow.GetConnection().QueryAsync<Class>(
            "SELECT * FROM turma"
        );

        return result.ToList();
    }

    public async Task<Class> GetClassByIdAsync(int classId)
    {
        var parameters = new { classId };

        var result = await _uow.GetConnection().QueryFirstOrDefaultAsync<Class>(
            "SELECT * FROM turma WHERE id = @classId;",
            parameters
        );

        return result;
    }

    public async Task<Class> GetClassByNameAsync(string className)
    {
        var parameters = new { className };

        var result = await _uow.GetConnection().QueryFirstOrDefaultAsync<Class>(
            "SELECT * FROM turma WHERE turma = @className;",
            parameters
        );

        return result;
    }

    public async Task InactivateClassAsync(int classId)
    {
        var parameters = new { classId };

        var result = await _uow.GetConnection().ExecuteAsync(@"
            DELETE FROM turma WHERE id = @classId
        ", parameters);
    }

    public async Task UpdateClassAsync(Class updatedClass)
    {
        var parameters = new
        {
            Id = updatedClass.Id,
            ClassName = updatedClass.ClassName,
            Year = updatedClass.Year,
        };

        await _uow.GetConnection().ExecuteAsync(@"
            UPDATE turma SET 
                turma = @ClassName, 
                ano = @Year
            WHERE id = @Id
        ", parameters);
    }
}