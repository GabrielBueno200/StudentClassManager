using System.Data;

namespace StudentClassManager.Infrastructure.Persistence.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IDbConnection? GetConnection();
    IDbTransaction? GetTransaction();
    void BeginTransaction();
    void Commit();
    void Rollback();
}