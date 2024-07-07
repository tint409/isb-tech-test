using ISBTest.Common.Units;
using ISBTest.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISBTest.DAL.DataProviders;

public class ISBTestDbContext(DbContextOptions<ISBTestDbContext> options) : DbContext(options)
{
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Money>()
            .HaveConversion<MoneyValueConverter>();
    }

    private readonly Guid[] SeedingGuids = [
        new Guid("872A1A41-CB52-4DB9-AC88-4E04DDB5E67D"),
        new Guid("BF987682-1335-4ECB-808D-51C6BF3A7ED3"),
        new Guid("B456B0AA-57CF-4D84-82E9-6347C3C6DCF1"),
        new Guid("FE9E1BB2-1528-429B-909F-71D7126285E1"),
        new Guid("CBE6114C-7A72-400B-98FA-86D725A8CB22")];
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>().HasData(
            Enumerable.Range(1, 5).Select(x => new Property 
            { 
                Id = SeedingGuids[x - 1],
                Name = "Name " + x,
                Address = "Address " + x,
                DateOfRegistration = DateTime.UtcNow.Date.AddDays(x),
                Price = new Money(x * 10000),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            }));

        base.OnModelCreating(modelBuilder);
    }
}
