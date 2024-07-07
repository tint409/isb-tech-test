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

    private readonly Guid[] SeedingPropertyGuids = [
        new Guid("872A1A41-CB52-4DB9-AC88-4E04DDB5E67D"),
        new Guid("BF987682-1335-4ECB-808D-51C6BF3A7ED3"),
        new Guid("B456B0AA-57CF-4D84-82E9-6347C3C6DCF1")];

    private readonly Guid[] SeedingContactGuids = [
        new Guid("639812A1-AD91-44AC-946B-C9C0AD0FC908"),
        new Guid("3714DABC-2E57-43E3-8EB1-89A0A78ED02F"),
        new Guid("2370B0CC-D432-4608-9CE4-922017F9EE8E")];

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>().HasData(new List<Property>
        {
            new()
            {
                Id = SeedingPropertyGuids[0],
                Name = "Hcm Maisonette",
                Address = "Hcm Maisonette Address",
                Price = new Money(130000, "EUR"),
                CreatedAt = DateTime.UtcNow,
                DateOfRegistration = DateTime.UtcNow
            },
            new()
            {
                Id = SeedingPropertyGuids[1],
                Name = "Cantho Maisonette",
                Address = "Cantho Maisonette Address",
                Price = new Money(110000, "EUR"),
                CreatedAt = DateTime.UtcNow,
                DateOfRegistration = DateTime.UtcNow
            },
            new()
            {
                Id = SeedingPropertyGuids[2],
                Name = "Penhouse",
                Address = "Penhouse",
                Price = new Money(430000, "EUR"),
                CreatedAt = DateTime.UtcNow,
                DateOfRegistration = DateTime.UtcNow
            }
        });

        modelBuilder.Entity<Contact>().HasData(new List<Contact>
        {
            new()
            {
                Id = SeedingContactGuids[0],
                FirstName = "Carmen",
                LastName = "Attard",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = SeedingContactGuids[1],
                FirstName = "Joshua",
                LastName = "Mifsud",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = SeedingContactGuids[2],
                FirstName = "Joe",
                LastName = "Borg",
                CreatedAt = DateTime.UtcNow
            }
        });

        modelBuilder.Entity<OwnershipChange>().HasData(new List<OwnershipChange>
        { 
            new()
            {
                PropertyId = SeedingPropertyGuids[0],
                EffectiveDate = new DateTime(2024, 08, 01),
                ContactId = SeedingContactGuids[0],
                AskingPrice = new Money(130000, "EUR"),
                SoldPrice = new Money(120000, "EUR"),
                SoldPriceAtUsd = new Money(140000)
            },
            new()
            {
                PropertyId = SeedingPropertyGuids[0],
                EffectiveDate = new DateTime(2025, 02, 01),
                ContactId = SeedingContactGuids[1],
                AskingPrice = new Money(150000, "EUR"),
                SoldPrice = new Money(140000, "EUR"),
                SoldPriceAtUsd = new Money(165000)
            }
        });

        base.OnModelCreating(modelBuilder);
    }
}
