using Dapper;
using StudentClassManager.Domain.Interfaces.Repositories;
using StudentClassManager.Domain.Models;
using StudentClassManager.Infrastructure.Persistence.UnitOfWork;

namespace StudentClassManager.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IUnitOfWork _uow;

    public StudentRepository(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public Task ActivateStudentAsync(int studentId, bool isActive)
    {
        throw new NotImplementedException();
    }

    public async Task<Student> CreateAsync(Student studentToCreate)
    {
        var parameters = new
        {
            Name = studentToCreate.Name,
            UserName = studentToCreate.UserName,
            Password = studentToCreate.Password
        };

        var result = await _uow.GetConnection().QueryFirstOrDefaultAsync<Student>(@"
            INSERT INTO aluno (nome, usuario, senha)
            VALUES (@Name, @UserName, @Password);

            SELECT * FROM aluno WHERE id = SCOPE_IDENTITY();
        ", parameters);

        return result;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        var result = await _uow.GetConnection().QueryAsync<Student>(
            "SELECT * FROM aluno"
        );

        return result.ToList();
    }

    public async Task<Student> GetStudentByIdAsync(int studentId)
    {
        var parameters = new
        {
            Id = studentId
        };

        var result = await _uow.GetConnection().QueryFirstOrDefaultAsync<Student>(
            "SELECT * FROM aluno WHERE id = @Id;",
            parameters
        );

        return result;
    }

    public async Task UpdateStudentAsync(Student updatedStudent)
    {
        var parameters = new
        {
            Id = updatedStudent.Id,
            Name = updatedStudent.Name,
            UserName = updatedStudent.UserName,
            Password = updatedStudent.Password
        };

        await _uow.GetConnection().ExecuteAsync(@"
            UPDATE aluno SET 
                nome = @Name, 
                usuario = @UserName, 
                senha = @Password
            WHERE id = @Id
        ", parameters);
    }
}
