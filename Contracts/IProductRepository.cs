using BikeApi.DTOs;
using BikeApi.Model;

namespace BikeApi.Contracts;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(ProductForCreationDTO product);
    Task UpdateProductAsync(int id, ProductForUpdateDTO product);
    Task DeleteProductAsync(int id);
}
