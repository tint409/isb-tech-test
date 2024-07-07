using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISBTest.DAL.Entities;

public interface IEntity
{
    DateTime CreatedAt { set; }
    DateTime UpdatedAt { set; }
}

public class BaseEntity<TKey> : IEntity where TKey : struct
{
    // [DEMO ONLY]
    // Some commonly used properties are listed here.
    // Some auto-populated value properties are also be handled in 1 place, see `ISBTestDbContext.cs` to know how CreatedAt and UpdatedAt populated.

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public TKey? Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
}
