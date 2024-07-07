using ISBTest.Common.Units;

namespace ISBTest.WebApi.Models;

public record OwnershipChangeModel
{
    /// <summary>
    /// Property Id
    /// </summary>
    public Guid PropertyId { get; set; }
    /// <summary>
    /// Effective Date or purchase date.
    /// </summary>
    public DateTime EffectiveDate { get; set; }
    /// <summary>
    /// Contact Id
    /// </summary>
    public Guid ContactId { get; set; }
    /// <summary>
    /// Asking Price
    /// </summary>
    public Money AskingPrice { get; set; } = new Money();
    /// <summary>
    /// Sold Price
    /// </summary>
    public Money SoldPrice { get; set; } = new Money();
    /// <summary>
    /// Sold Price converted to Usd at the purchase date point of time.
    /// </summary>
    public Money SoldPriceAtUsd { get; set; } = new Money();
    /// <summary>
    /// Contact Model
    /// </summary>
    public ContactModel? Contact { get; set; }
}
