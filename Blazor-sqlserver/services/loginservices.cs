using Microsoft.EntityFrameworkCore;
using Blazor.Data;
namespace Blazor.Services;
public class LoginServices(ApplicationDBcontext db)
{
    private readonly ApplicationDBcontext _db = db;
    public async Task<bool> Login(string username, string? password) =>
        await _db.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password) != null;
}

