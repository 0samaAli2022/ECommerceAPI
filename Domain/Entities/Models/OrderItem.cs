using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Models;
public class OrderItem : BaseEntity<Guid>
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
}
