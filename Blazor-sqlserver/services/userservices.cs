using Microsoft.EntityFrameworkCore;
using Blazor.Data;
using Blazor.Models;
namespace Blazor.Services
{
    public class UserService
    {
        private bool _isLoggedIn = false;

        public bool IsLoggedIn => _isLoggedIn;



        public void SetLoginState(bool isLoggedIn)
        {
            _isLoggedIn = isLoggedIn;
        }

        public void Logout()
        {
            _isLoggedIn = false;
        }
    }

}
