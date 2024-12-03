namespace Domain.Entities.Exceptions;

public class CartItemNotFoundException : NotFoundException
{
    public CartItemNotFoundException(Guid id) : base($"Cart Item with id: {id} does not exist.") { }
}
