
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;


public class Cart : BaseEntity<Guid>
{
    public required string UserId { get; set; }
    [NotMapped]
    public decimal TotalPrice => Items?.Sum(item => item.Product!.Price * item.Quantity) ?? 0m;
    public virtual ICollection<CartItem> Items { get; set; } = [];
    public virtual User? User { get; set; }
}
