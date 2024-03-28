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
        var identityResult = await _userManager.CreateAsync(_mapper.Map<AppUser>(request), request.Password);

        if (identityResult.Succeeded)
            return new UserRegisterCommandResponse("The user has registered successfully."); //todo refactor here


        throw new UserRegisterFailedException("We encountered an unexpected error while creating the user."); //todo return errorss
    }
}
         