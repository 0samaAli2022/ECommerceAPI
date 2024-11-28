namespace Domain.Entities.Exceptions;

public sealed class EmptyCartException : BadRequestException
{
    public EmptyCartException()
    : base("Cannot place an order on an empty cart.")
    {
    }
}
