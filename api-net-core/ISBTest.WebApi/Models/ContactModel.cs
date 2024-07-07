namespace ISBTest.WebApi.Models;

public record ContactModel
{
    /// <summary>
    /// Contact Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Contact FirstName
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// Contact LastName
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// Contact Phone
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// Contact Email
    /// </summary>
    public string? Email { get; set; }
}
