namespace Domain.Entities.Exceptions;

public sealed class UpdateItemQuantityBadRequestException : BadRequestException
{
    public UpdateItemQuantityBadRequestException(int quantity)
    : base($"Item quantity cannot be less than 1 or greater than product stock quantity: {quantity}.")
    {
    }
}