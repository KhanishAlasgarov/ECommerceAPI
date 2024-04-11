using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ECommerceAPI.API.Controllers;

public class RolesController : BaseController
{
    RoleManager<AppRole> _roleManager;

    public RolesController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create(string role)
    {

        var result = await _roleManager.CreateAsync(new AppRole
        {
            Name = role
        });

        if (result.Succeeded)
        {
            return Ok();
        }

        StringBuilder stringBuilder = new();
        foreach (var item in result.Errors)
        {
            stringBuilder.Append(item.Description + "\n");

        }

        return Ok(stringBuilder.ToString());


    }
}
