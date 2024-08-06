using Microsoft.EntityFrameworkCore;
using Blazor.Data;
namespace Blazor.Services;
public class LoginServices(ApplicationDBcontext DB)
{
    public async Task<bool> Login(string? username, string? password) =>
        (await DB.Users.AnyAsync(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase) && u.Password == password));
}

