using Microsoft.EntityFrameworkCore;
using Blazor.Data;
using Blazor.Models;


namespace Blazor.Services

{
    public class Loginservices(ApplicationDBcontext db)
    {
        private readonly ApplicationDBcontext _db = db;
       // private readonly UserService _userStateService;
        public async Task<bool> Login(string username, string ? password)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        if (user != null)
        {
              //  _userStateService.SetLoginState(true);
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
        // make a function to logout when i refresh the page
        public async Task Logout()
        {
            await Task.Delay(0);
        }
        // make a function to check if the user is logged in
        //public bool IsLoggedIn()
        //{
        //    return _userStateService.IsLoggedIn;
        //}




    }
}
