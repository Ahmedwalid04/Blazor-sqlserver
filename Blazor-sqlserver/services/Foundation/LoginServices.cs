using Blazor.Models;
using Dapper;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Task.Broker.Storages;
namespace services.Foundation;
public class LoginServices(StorageBroker storageBroker, ProtectedLocalStorage LocalStorage)
{
    public bool IsLoggedIn { get; set; }
    public bool Login(string? UserName, string? Password)
    {
        using var connection = storageBroker.CreateConnection();
        var query = "SELECT COUNT(1) FROM Users WHERE UserName = @UserName AND Password = @Password";
        var count = connection.ExecuteScalar<int>(query, new { UserName , Password  });
        return count > 0;

    }
    public void Login(Users Users)
     => IsLoggedIn = storageBroker.SelectUserByUsernameAndPassword(
         Users.UserName ?? string.Empty,
         Users.Password ?? string.Empty) is not null;

    public async ValueTask AutoLogin()
    {
        var x = await LocalStorage.GetAsync<bool?>("IsLoggedIn");
        IsLoggedIn = x.Value ?? false;
    }
}

