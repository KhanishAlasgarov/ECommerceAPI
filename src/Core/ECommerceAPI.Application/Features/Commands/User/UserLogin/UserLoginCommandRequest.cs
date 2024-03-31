using MediatR;

namespace ECommerceAPI.Application.Features.Commands.User.UserLogin;

public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
{
    public string UsernameOrEmail { get; set; } = default!;
    public string Password { get; set; } = default!;
}
