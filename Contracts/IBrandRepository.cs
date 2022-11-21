using BikeApi.Model;

namespace BikeApi.Contracts;
public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetBrandsAsync();
    Task<Brand> GetBrandByIdAsync(int id);
    Task<Brand> CreateBrandAsync(Brand brand);
    Task UpdateBrandAsync(int id, Brand brand);
    Task DeleteBrandAsync(int id);
}
