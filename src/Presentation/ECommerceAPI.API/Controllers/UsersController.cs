using ECommerceAPI.Application.Features.Commands.User.UserLogin;
using ECommerceAPI.Application.Features.Commands.User.UserRegister;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers;


public class UsersController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] UserRegisterCommandRequest userRegisterCommandRequest)
    {
        // Auto Mapper problemi var onu hell et ve success olmadigi teqdirde errorlari geri qaytar
        return Ok(await Mediator.Send(userRegisterCommandRequest));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Login(UserLoginCommandRequest userLoginCommandRequest)
    {
        var response =await Mediator.Send(userLoginCommandRequest);
        return Ok(response);
    }

}
