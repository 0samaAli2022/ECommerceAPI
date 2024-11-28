namespace Entities.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id) : base($"Product with id: {id} does not exist.") { }
}
