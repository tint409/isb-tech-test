using ISBTest.DAL.Contracts;
using ISBTest.DAL.DataProviders;

namespace ISBTest.DAL;

public class UnitOfWork : IUnitOfWork, IUnitOfWorkInternal
{
    // [DEMO NOTE]
    // We want to save all changes at once after http request is finished, to avoid multiple db hits.

    private readonly ISBTestDbContext _dbContext;

    private bool _disposed;

    public UnitOfWork(ISBTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public Task<int> CommitAsync() => _dbContext.SaveChangesAsync();

    ~UnitOfWork()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _dbContext.Dispose();
        _disposed = true;
    }

    ISBTestDbContext IUnitOfWorkInternal.DbContext => _dbContext;
}
