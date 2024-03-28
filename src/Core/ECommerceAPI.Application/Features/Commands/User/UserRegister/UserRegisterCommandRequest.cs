using MediatR;

namespace ECommerceAPI.Application.Features.Commands.User.UserRegister;

public class UserRegisterCommandRequest : IRequest<UserRegisterCommandResponse>
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}
