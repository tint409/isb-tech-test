using ISBTest.Common.Units;

namespace ISBTest.WebApi.Models;

public record ChangeOwnerModel
{
    /// <summary>
    /// New owner Contact Id
    /// </summary>
    public Guid ContactId { get; set; }
    /// <summary>
    /// Purchase Date
    /// </summary>
    public DateTime PurchaseDate { get; set; }
    /// <summary>
    /// Asking Price at any currency
    /// </summary>
    public Money AskingPrice { get; set; } = new Money();
    /// <summary>
    /// Sold Price at any currency
    /// </summary>
    public Money SoldPrice { get; set; } = new Money();
}
