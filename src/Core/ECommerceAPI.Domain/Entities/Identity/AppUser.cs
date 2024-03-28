using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Domain.Entities.Identity;

public class AppUser : IdentityUser<Guid>
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
}
