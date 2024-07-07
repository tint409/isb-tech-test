using ISBTest.Common.Units;

namespace ISBTest.WebApi.Models;

public class PropertyModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Money Price { get; set; } = new Money();
    public DateTime? DateOfRegistration { get; set; } 
}
