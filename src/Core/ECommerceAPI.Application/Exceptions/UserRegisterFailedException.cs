namespace ECommerceAPI.Application.Exceptions;

internal class UserRegisterFailedException : Exception
{
    public UserRegisterFailedException(string? message) : base(message)
    {
    }

    public UserRegisterFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
