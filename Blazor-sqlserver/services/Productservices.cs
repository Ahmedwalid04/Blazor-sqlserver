using Microsoft.EntityFrameworkCore;
using Blazor.Data;
namespace Blazor_sqlserver.Services;
public class ProductServices(ApplicationDBcontext _context)
{
    //get all products
    public async Task<List<Product>> GetProductsAsync() => await _context.Product.ToListAsync();
    //update product
    public async Task UpdateProductAsync(Product product) => await  _context.Product.Update(product).Context.SaveChangesAsync();
    //add product
    public async Task AddProductAsync(Product product) => await _context.Product.Add(product).Context.SaveChangesAsync();
    //delete product
    public async ValueTask DeleteProductAsync(int id) => await _context.Product.Remove((await _context.Product.FindAsync(id)) ?? throw new ApplicationException("An error occurred while deleting the product. (ID Not found)")).Context.SaveChangesAsync();
}