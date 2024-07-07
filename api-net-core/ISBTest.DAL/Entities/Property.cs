using ISBTest.Common.Units;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISBTest.DAL.Entities;

[Table(nameof(Property))]
public class Property : BaseEntity<Guid>
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public Money Price { get; set; } = new Money(0);
    [Required]
    public DateTime DateOfRegistration { get; set; }

    public ICollection<OwnershipChange>? OwnershipChanges { get; set; }
}
