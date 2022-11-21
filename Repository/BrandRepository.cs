using System.Data;
using BikeApi.Context;
using BikeApi.Contracts;
using BikeApi.Model;
using Dapper;

namespace BikeApi.Repository;

public class BrandRepository : IBrandRepository
{
    private readonly DapperContext _context;
    public BrandRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Brand> GetBrandByIdAsync(int id)
    {
        var query = @"SELECT Id, Name
                    FROM Brands
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        var brand = await connection.QuerySingleOrDefaultAsync<Brand>(query, new { id });

        return brand;
    }

    public async Task<IEnumerable<Brand>> GetBrandsAsync()
    {
        var query = @"SELECT Id, Name
                    FROM Brands";

        using var connection = _context.CreateConnection();

        var brands = await connection.QueryAsync<Brand>(query);

        return brands;
    }
    public async Task<Brand> CreateBrandAsync(Brand brand)
    {
        var query = @"INSERT INTO Brands(Name)
                    VALUES(@name);
                    SELECT CAST(SCOPE_IDENTITY() AS int)";

        using var connection = _context.CreateConnection();

        var queryParameters = new DynamicParameters();
        queryParameters.Add("name", brand.Name, DbType.String);

        var id = await connection.QuerySingleAsync<int>(query, queryParameters);

        var createdBrand = new Brand
        {
            Id = id,
            Name = brand.Name
        };

        return createdBrand;
    }
    public async Task UpdateBrandAsync(int id, Brand brand)
    {
        var query = @"UPDATE Brands
                    SET Name = @name
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        var queryParameters = new DynamicParameters();
        queryParameters.Add("Id", id, DbType.Int32);
        queryParameters.Add("name", brand.Name, DbType.String);

        await connection.ExecuteAsync(query, queryParameters);
    }
    public async Task DeleteBrandAsync(int id)
    {
        var query = @"DELETE FROM Brands
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { id });
    }

    public async Task<Brand> GetBrandByProductsMultipleResultsAsync(int id)
    {
        var query = @"SELECT Id, Name
                    FROM Brands
                    WHERE Id = @Id;
                    
                    SELECT Id, Name, ModelYear, Price, BrandId, CategoryId
                    FROM Products 
                    WHERE BrandId = @Id;";

        using var connection = _context.CreateConnection();

        using var multi = await connection.QueryMultipleAsync(query, new { id });

        var brand = await multi.ReadSingleOrDefaultAsync<Brand>();
        if (brand != null)
            brand.Products = (await multi.ReadAsync<Product>()).ToList();

        return brand;
    }

    public async Task<List<Brand>> GetBrandByProductsMultipleMappingAsync()
    {
        var query = @"SELECT br.Id, br.Name,
                    pr.Id, pr.Name, ModelYear, Price, BrandId, CategoryId
                    FROM Brands br
                    JOIN Products pr
                    ON br.Id = pr.BrandId";

        using var connection = _context.CreateConnection();

        var brands = new List<Brand>();
        var items = await connection.QueryAsync<Brand, Product, Brand>(
            query,
            (brand, product) =>
            {
                var br = brands.FirstOrDefault(x => x.Id == brand.Id);
                if (br is null)
                {
                    br = brand;
                    br.Products.Add(product);
                    brands.Add(br);
                }
                else
                    br.Products.Add(product);

                return brand;
            }
        );

        return items.ToList();
    }
}
