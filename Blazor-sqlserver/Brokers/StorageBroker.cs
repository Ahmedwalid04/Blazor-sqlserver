using Blazor.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Task.Broker.Storages;
public class StorageBroker(IConfiguration configuration)
{
    public SqlConnection CreateConnection() => new(ConnectionString);
    static CommandType StoredProc => CommandType.StoredProcedure;
    string? ConnectionString => configuration.GetConnectionString("DefaultConnection");
    public void InsertProduct(string? Name, decimal? Price)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute("InsertProduct", new { Name, Price }, commandType: StoredProc);
    }
    public void UpdateProduct(int? Id, string? Name, decimal? Price)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute("UpdateProduct", new { Id, Name, Price }, commandType: StoredProc);
    }
    public void DeleteProduct(int? Id)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute("DeleteProduct", new { Id }, commandType: StoredProc);
    }
    public Product SelectProduct(int? Id)
    {
        using var connection = new SqlConnection(ConnectionString);
        return connection.QueryFirstOrDefault<Product>("SelectProduct", new { Id }, commandType: StoredProc) ?? new Product();
    }
    public IEnumerable<Product> SelectAllProducts()
    {
        using var connection = new SqlConnection(ConnectionString);
        return connection.Query<Product>("SelectListProduct", commandType: StoredProc);
    }



}