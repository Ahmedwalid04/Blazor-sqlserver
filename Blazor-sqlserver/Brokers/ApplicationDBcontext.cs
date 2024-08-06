using Microsoft.EntityFrameworkCore;
using Blazor.Models;
/// <summary>
/// Represents the application's database context for Entity Framework Core.
/// This class manages the connection to the database and provides access to the entities through DbSets.
/// </summary>
namespace Blazor.Data;
public class ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : DbContext(options)
{
    public DbSet<Product> Product { get; set; }
    public DbSet<Users> Users { get; set; }
}