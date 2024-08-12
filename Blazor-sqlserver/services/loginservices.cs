using Dapper;
using Task.Broker.Storages;
namespace Blazor.Services;
public class LoginServices(StorageBroker storageBroker)
{
    public async Task<bool> Login(string? username, string? password)
    {
        using (var connection = storageBroker.CreateConnection())
        {
            var query = "SELECT COUNT(1) FROM Users WHERE UserName = @UserName AND Password = @Password";
            var count = await connection.ExecuteScalarAsync<int>(query, new { UserName = username, Password = password });
            return count > 0;
        }
    }
}

