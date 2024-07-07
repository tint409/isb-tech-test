using ISBTest.DAL;
using ISBTest.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ISBTest.BL;

public class PropertyDataLoader(IRepository<Property> _repository) : DataLoader<Property>(_repository)
{
    public override Task<Property?> Get(Expression<Func<Property, bool>>? filter = null, bool asNoTracking = true)
        => _repository.Query(filter, asNoTracking)
            .Include(x => x.OwnershipChanges)!
            .ThenInclude(x => x.Contact)
            .FirstOrDefaultAsync();
}