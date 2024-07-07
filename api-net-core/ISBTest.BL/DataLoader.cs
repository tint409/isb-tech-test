using ISBTest.DAL;
using System.Linq.Expressions;

namespace ISBTest.BL;

public interface IDataLoader<TEntity> where TEntity : class
{
    Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true);
    Task<TEntity?> Get(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true);
}

public class DataLoader<TEntity>(IRepository<TEntity> _repository) : IDataLoader<TEntity> where TEntity : class
{
    // [DEMO NOTE
    // We shouldn't allow Api layer to directly access DAL. It needs use this class as middle man for extra logic if needed.
    // Since this demo only load some data, so this just uses Proxy pattern.

    public Task<TEntity?> Get(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true)
        => _repository.Get(filter, asNoTracking);

    public Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true)
        => _repository.List(filter, asNoTracking);
}
