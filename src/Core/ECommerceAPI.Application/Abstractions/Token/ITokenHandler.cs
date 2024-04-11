using ECommerceAPI.Domain.Entities.Identity;
using Dto = ECommerceAPI.Application.DTOs;
namespace ECommerceAPI.Application.Abstractions.Token;

public interface ITokenHandler
{
    Dto::Token CreateAccessToken(int second, AppUser appUser, IList<string> roles);
    string CreateRefreshToken();
}
