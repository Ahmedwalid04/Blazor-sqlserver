using Blazor.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Task.Broker.Storages;
public class StorageBroker(IConfiguration configuration)
{
    public SqlConnection CreateConnection() => new (ConnectionString);
    static CommandType StoredProc => CommandType.StoredProcedure;
    string? ConnectionString => configuration.GetConnectionString("DefaultConnection");
    public void InsertProduct(string? Name, decimal? Price)
    {
        using var connection = CreateConnection();
        connection.Execute("InsertProduct", new { Name, Price }, commandType: StoredProc);
    }
    public void UpdateProduct(int? Id, string? Name, decimal? Price)
    {
        using var connection = CreateConnection();
        connection.Execute("UpdateProduct", new { Id, Name, Price }, commandType: StoredProc);
    }
    public void DeleteProduct(int? Id)
    {
        using var connection = CreateConnection();
        connection.Execute("DeleteProduct", new { Id }, commandType: StoredProc);
    }
    public Product? SelectProduct(int? Id)
    {
        using var connection = CreateConnection();
        return connection.QueryFirstOrDefault<Product>("SelectProduct", new { Id }, commandType: StoredProc);
    }
    public IEnumerable<Product> SelectAllProducts()
    {
        using var connection = CreateConnection();
        return connection.Query<Product>("SelectListProduct", commandType: StoredProc);
    }
   public Users? SelectUserByUsernameAndPassword(string Username,string Password)
    {
        using var connection = CreateConnection();
        return connection.QueryFirstOrDefault<Users>("SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password", new { Username, Password });
    }
}