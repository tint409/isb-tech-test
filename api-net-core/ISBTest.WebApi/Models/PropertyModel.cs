using ISBTest.Common.Units;

namespace ISBTest.WebApi.Models;

public record PropertyModel
{
    /// <summary>
    /// Propery Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Property Name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Property Address
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Latest Sold Price of the property
    /// </summary>
    public Money Price { get; set; } = new Money();
    /// <summary>
    /// Date of Registration
    /// </summary>
    public DateTime? DateOfRegistration { get; set; }
    /// <summary>
    /// History of ownership changes
    /// </summary>
    public OwnershipChangeModel[] OwnershipChanges { get; set; } = [];
}
