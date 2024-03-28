namespace ECommerceAPI.Application.Features.Commands.User.UserRegister;

public class UserRegisterCommandResponse
{
    public UserRegisterCommandResponse(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}