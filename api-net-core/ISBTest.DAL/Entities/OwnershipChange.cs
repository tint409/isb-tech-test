using ISBTest.Common.Units;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISBTest.DAL.Entities;

[Table(nameof(OwnershipChange))]
[PrimaryKey(nameof(PropertyId), nameof(EffectiveDate))]
public class OwnershipChange
{
    public Guid PropertyId { get; set; }
    public DateTime EffectiveDate { get; set; }
    [Required]
    public Guid ContactId { get; set; }
    public Money AskingPrice { get; set; } = new Money();
    public Money SoldPrice { get; set; } = new Money();
    public Money SoldPriceAtUsd { get; set; } = new Money();

    [ForeignKey(nameof(PropertyId))]
    public Property? Property { get; set; }

    [ForeignKey(nameof(ContactId))]
    public Contact? Contact { get; set; }
}
