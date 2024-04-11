using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dto = ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    IConfiguration _configuration { get; }

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Dto::Token CreateAccessToken(int second, AppUser appUser, IList<string> roles)
    {
        Dto::Token token = new();
        var claims = new List<Claim> { new(ClaimTypes.Name, appUser.UserName!) };

        foreach (var item in roles)
        {
            claims.Add(new(ClaimTypes.Role, item));
        }
        var securityKey = _configuration["Token:SecurityKey"];
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(securityKey!));

        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.UtcNow.AddMinutes(second);
        token.Expiration = expires;

        JwtSecurityToken jwtSecurityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            signingCredentials: signingCredentials,
            expires: expires,
            notBefore: DateTime.UtcNow,
            claims: claims);

        JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();

        token.AccessToken = jwtHandler.WriteToken(jwtSecurityToken);

        return token;

    }

    public string CreateRefreshToken()
    {
        throw new NotImplementedException();
    }
}
