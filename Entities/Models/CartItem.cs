using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models;

public class CartItem : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }
    public Guid CartId { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    [NotMapped]
    public decimal TotalPrice => Quantity * Product!.Price;
    public virtual Product? Product { get; set; }
    public virtual Cart? Cart { get; set; }
}
