using ISBTest.DAL.Contracts;
using ISBTest.DAL.DataProviders;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ISBTest.DAL;

public interface IRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true);
    Task<TEntity?> Get(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true);
    Task Add(TEntity entity);
}

public class Repository<TEntity>(IUnitOfWork unitOfWork) : IRepository<TEntity> where TEntity : class
{
    // [DEMO ONLY]
    // We want to use same scoped DbContext instance.
    // This is to make sure all access to DbContext going through unitOfWork (unitOfWork is injected as "scoped")
    // Why casting to IUnitOfWorkInternal? Because we dont want BL layer to directly access to DbContext.

    private readonly ISBTestDbContext _dbContext = ((IUnitOfWorkInternal)unitOfWork).DbContext;

    private IQueryable<TEntity> PrepareQuery(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true)
    {
        var query = asNoTracking ? _dbContext.Set<TEntity>().AsNoTracking() : _dbContext.Set<TEntity>();
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return query;
    }

    public Task<TEntity?> Get(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true)
        => PrepareQuery(filter, asNoTracking).FirstOrDefaultAsync();

    public Task<List<TEntity>> List(Expression<Func<TEntity, bool>>? filter = null, bool asNoTracking = true)
        => PrepareQuery(filter, asNoTracking).ToListAsync();

    public async Task Add(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);
}
