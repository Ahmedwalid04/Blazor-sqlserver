using Microsoft.EntityFrameworkCore;
using Blazor.Data;
using Blazor.Models;
namespace Blazor.Services

{
    public class Loginservices(ApplicationDBcontext db)
    {
        private readonly ApplicationDBcontext _db = db;

        public async Task<bool> Login(string username, string ? password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        if (user != null)
        {
            return true;
        }
        return false;
    }
    public async Task<bool> Register(string username, string password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null)
        {
            _db.Users.Add(new Users { UserName = username, Password = password });
            await _db.SaveChangesAsync();
            return true;
        }
        return false;
    }
        // make a function isloggedin
      
      

}
}
