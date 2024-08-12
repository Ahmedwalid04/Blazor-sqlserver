using Task.Broker.Storages;
using Dapper;
using Blazor.Models;
using Blazor.services.Foundation;
namespace services.Foundation;
public class ProductServices(StorageBroker storageBroker) : IProductServices
{
    public void AddProduct(Product product) 
        => storageBroker.InsertProduct(product.Name, product.Price);
    public void ModifyProduct(Product product) 
        => storageBroker.UpdateProduct(product.Id, product.Name, product.Price);
    public void RemoveProduct(int id) 
        => storageBroker.DeleteProduct(id);
    public Product SelectProduct(int id) 
        => storageBroker.SelectProduct(id);
    public IEnumerable<Product> SelectAllProducts() 
        => storageBroker.SelectAllProducts();   
} 