using ISBTest.DAL.DataProviders;

namespace ISBTest.DAL.Contracts;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}

internal interface IUnitOfWorkInternal
{
    ISBTestDbContext DbContext { get; }
}
