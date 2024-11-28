using Microsoft.AspNetCore.Identity;

namespace Entities.Models;
public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Address { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public virtual Cart? ShoppingCart { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = [];
}
