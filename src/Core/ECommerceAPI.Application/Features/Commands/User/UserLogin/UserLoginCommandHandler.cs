using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace ECommerceAPI.Application.Features.Commands.User.UserLogin;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
{
    public UserLoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, ITokenHandler tokenHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _tokenHandler = tokenHandler;
    }
    IConfiguration _configuration { get; }
    UserManager<AppUser> _userManager { get; }
    SignInManager<AppUser> _signInManager { get; }
    ITokenHandler _tokenHandler { get; }
    public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? user = default;
        string? pattern = _configuration["MailPattern"];

        if (!string.IsNullOrWhiteSpace(pattern) && Regex.IsMatch(request.UsernameOrEmail, pattern))
            user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
        else
            user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

        if (user == null)
            throw new Exception(); //todo

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        var roles = await _userManager.GetRolesAsync(user);

        if (result.Succeeded)
        {
            var token = _tokenHandler.CreateAccessToken(600, user,roles);

            return new UserLoginCommandResponse(token);
        }
        else
            throw new Exception(); //todo
    }
}
