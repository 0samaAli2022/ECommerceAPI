using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models;

public class Order : BaseEntity<Guid>
{
    public required string UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(18,2)")]
    public required decimal TotalPrice { get; set; }
    public virtual ICollection<OrderItem> Items { get; set; } = [];
    public virtual User? User { get; set; }
}
