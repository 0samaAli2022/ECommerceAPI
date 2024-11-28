namespace Domain.Entities.Exceptions;

public sealed class AddItemQuantityBadRequestException : BadRequestException
{
    public AddItemQuantityBadRequestException()
    : base("Item Quantity Cannot Exceed Product Stock Quantity.")
    {
    }
}