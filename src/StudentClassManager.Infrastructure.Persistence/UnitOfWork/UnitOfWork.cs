using System.Data;
using System.Data.SqlClient;

namespace StudentClassManager.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly string _connectionString;

    public SqlConnection? Connection { get; protected set; }
    public SqlTransaction? Transaction { get; protected set; }

    public UnitOfWork(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void BeginTransaction()
    {
        if (Connection == null)
        {
            Connection = new SqlConnection(_connectionString);
            Connection.Open();
        }

        Transaction = Connection.BeginTransaction();
    }

    public void Commit()
    {
        try
        {
            Transaction?.Commit();
        }
        catch
        {
            Transaction?.Rollback();
            throw;
        }
        finally
        {
            Transaction?.Dispose();
            Transaction = null;
        }
    }

    public void Rollback()
    {
        try
        {
            Transaction?.Rollback();
        }
        finally
        {
            Transaction?.Dispose();
            Transaction = null;
        }
    }

    public IDbConnection? GetConnection()
    {
        if (Connection != null) return Connection;
        Connection = new SqlConnection(_connectionString);
        Connection.Open();

        return Connection;
    }

    public IDbTransaction? GetTransaction() => Transaction;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing) return;

        if (Connection != null)
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}