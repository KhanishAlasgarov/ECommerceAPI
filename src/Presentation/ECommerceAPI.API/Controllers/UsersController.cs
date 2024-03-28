using ECommerceAPI.Application.Features.Commands.User.UserRegister;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers;


public class UsersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterCommandRequest userRegisterCommandRequest)
    {
       // Auto Mapper problemi var onu hell et ve success olmadigi teqdirde errorlari geri qaytar
        return Ok(await Mediator.Send(userRegisterCommandRequest));
    }
}
