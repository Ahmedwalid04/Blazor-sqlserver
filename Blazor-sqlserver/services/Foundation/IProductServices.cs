using Blazor.Models;
namespace Blazor.services.Foundation;
public interface IProductServices
{
    public IEnumerable<Product> SelectAllProducts();
    public Product SelectProduct(int? id);
    public void ModifyProduct(Product product);
    public void AddProduct(Product product);
    public void RemoveProduct(int id);
}
