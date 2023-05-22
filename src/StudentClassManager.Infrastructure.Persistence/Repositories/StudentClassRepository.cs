using Dapper;
using StudentClassManager.Domain.Models;
using StudentClassManager.Domain.Interfaces.Repositories;
using StudentClassManager.Infrastructure.Persistence.UnitOfWork;

namespace StudentClassManager.Infrastructure.Persistence.Repositories;

public class StudentClassRepository : IStudentClassRepository
{
    private readonly IUnitOfWork _uow;

    public StudentClassRepository(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task AssociateStudentWithClassAsync(int classId, int studentId)
    {
        var parameters = new { classId, studentId };

        var result = await _uow.GetConnection().ExecuteAsync(@"
            INSERT INTO aluno_turma (aluno_id, turma_id)
            VALUES (@studentId, @classId)
        ", parameters);
    }

    public async Task<IList<Student>> GetClassStudentsAsync(int classId)
    {
        var parameters = new { classId };

        var result = await _uow.GetConnection().QueryAsync<Student>(@"
            SELECT a.* FROM aluno a 
                JOIN aluno_turma t 
                ON a.id = t.aluno_id 
                WHERE t.turma_id = @classId
        ", parameters);

        return result.ToList();
    }

    public async Task<IList<Student>> GetStudentsToAssociate(int classId)
    {
        var parameters = new { classId };

        var result = await _uow.GetConnection().QueryAsync<Student>(@"
            SELECT *
                FROM aluno
                WHERE id NOT IN (
                    SELECT aluno_id
                    FROM aluno_turma
                    WHERE turma_id = @classId
                );
        ", parameters);

        return result.ToList();
    }

    public async Task RemoveStudentFromClassAsync(int classId, int studentId)
    {
        var parameters = new { classId, studentId };

        var result = await _uow.GetConnection().ExecuteAsync(
            "DELETE FROM aluno_turma WHERE turma_id = @classId AND aluno_id = @studentId", 
            parameters
        );
    }

    public async Task<bool> VerifyIfStudentIsInClass(int classId, int studentId)
    {
        var parameters = new { classId, studentId };

        var result = await _uow.GetConnection().QueryFirstOrDefaultAsync(
            "SELECT * FROM aluno_turma WHERE turma_id = @classId AND aluno_id = @studentId", 
            parameters
        );

        return result != null;
    }
}