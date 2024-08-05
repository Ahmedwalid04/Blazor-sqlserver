using Microsoft.EntityFrameworkCore;
using Blazor.Data;
using Blazor.Models;
namespace Blazor.Services;
public class Loginservices(ApplicationDBcontext db)
{
    private readonly ApplicationDBcontext _db = db;
    public async Task<bool> Login(string username, string? password) =>
        await _db.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password) != null;

    public async Task<bool> Register(string username, string password) =>
        await _db.Users.FirstOrDefaultAsync(u => u.UserName == username) != null;
}

