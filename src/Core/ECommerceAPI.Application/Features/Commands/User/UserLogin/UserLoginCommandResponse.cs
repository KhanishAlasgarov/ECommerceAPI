using ECommerceAPI.Application.DTOs;
using Dto = ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Features.Commands.User.UserLogin;

public class UserLoginCommandResponse
{
    public UserLoginCommandResponse(Token token)
    {
        this.token = token;
    }

    public Dto::Token token { get; set; }
}