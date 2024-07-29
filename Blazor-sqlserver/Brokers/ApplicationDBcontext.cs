using Microsoft.EntityFrameworkCore;

namespace Blazor.Data

{
    using Microsoft.EntityFrameworkCore;
    /// <summary>
    /// Represents the application's database context for Entity Framework Core.
    /// This class manages the connection to the database and provides access to the entities through DbSets.
    /// </summary>
    public class ApplicationDBcontext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {
        }
    }
}