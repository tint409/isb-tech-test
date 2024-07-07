using ISBTest.Common.Units;
using ISBTest.DAL;
using ISBTest.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISBTest.BL;

public interface IPropertyChangeOwnerProcessor
{
    Task<bool> Change(Guid propertyId, Guid newOwnerId, DateTime purchaseDate, Money askingPrice, Money soldPrice);
}

public class PropertyChangeOwnerProcessor(IRepository<Property> _propertyRepository, IRepository<Contact> _contactRepository, IRepository<OwnershipChange> _ownershipChangeRepository) : IPropertyChangeOwnerProcessor
{
    public async Task<bool> Change(Guid propertyId, Guid newOwnerId, DateTime purchaseDate, Money askingPrice, Money soldPrice)
    {
        var property = await _propertyRepository
            .Query(x => x.Id == propertyId)
            .Include(x => x.OwnershipChanges)
            .FirstOrDefaultAsync();
        if (property == null)
            return false;

        // [DEMO NOTE]
        // Normally, we want to throw exception here instead of return `false`.
        // And we should have an Exception filter at Api level to return different http status codes based on different exception types.
        // But in this demo, I skip that.

        var contact = await _contactRepository.Get(x => x.Id == newOwnerId);
        if (contact == null)
            return false;

        if (property.OwnershipChanges?.Any(x => x.EffectiveDate == purchaseDate) ?? false)
            return false; // Cannot change owner in the same time.

        // More validation if needed.

        var newChange = new OwnershipChange
        {
            PropertyId = propertyId,
            EffectiveDate = purchaseDate,
            ContactId = newOwnerId,
            AskingPrice = askingPrice,
            SoldPrice = soldPrice,
            SoldPriceAtUsd = new Money(soldPrice.Amount * 1.2m, "USD")
        };
        await _ownershipChangeRepository.Add(newChange);

        return true;
    }
}
