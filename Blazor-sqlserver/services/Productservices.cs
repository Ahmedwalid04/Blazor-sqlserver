using Microsoft.EntityFrameworkCore;
using Blazor.Data;
public class Productservices
{
    private readonly ApplicationDBcontext _context;

    public Productservices(ApplicationDBcontext context)
    {
        _context = context;
    }
    //get all products
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Product.ToListAsync();
    }
    //update product
    public async Task UpdateProductAsync(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }
    //add product
    public async Task AddProductAsync(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();
    }
    //delete product
    public async ValueTask DeleteProductAsync(int id)
    {
        try
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            throw new ApplicationException("An error occurred while deleting the product.", ex);
        }
    }

}