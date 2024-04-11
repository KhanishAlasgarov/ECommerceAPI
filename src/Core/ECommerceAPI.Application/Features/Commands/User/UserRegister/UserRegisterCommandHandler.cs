using AutoMapper;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Application.Features.Commands.User.UserRegister;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, UserRegisterCommandResponse>
{
    UserManager<AppUser> _userManager { get; }
    IMapper _mapper { get; }

    public UserRegisterCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserRegisterCommandResponse> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<AppUser>(request);
        var identityResult = await _userManager.CreateAsync(user, request.Password);

        if (identityResult.Succeeded)
        {

            await _userManager.AddToRoleAsync(user, "Member");
            return new UserRegisterCommandResponse("The user has registered successfully."); //todo refactor here
        }

        throw new UserRegisterFailedException(string.Join(", ", identityResult.Errors.Select(x => x.Description))); //todo return errorss
    }
}
