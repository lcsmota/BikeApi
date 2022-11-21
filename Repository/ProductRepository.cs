using System.Data;
using BikeApi.Context;
using BikeApi.Contracts;
using BikeApi.DTOs;
using BikeApi.Model;
using Dapper;

namespace BikeApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DapperContext _context;
    public ProductRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var query = @"SELECT Id, Name, ModelYear, Price, BrandId, CategoryId
                    FROM Products
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { id });

        return product;
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var query = @"SELECT Id, Name, ModelYear, Price, BrandId, CategoryId
                    FROM Products";

        using var connection = _context.CreateConnection();

        var products = await connection.QueryAsync<Product>(query);

        return products;
    }
    public async Task<Product> CreateProductAsync(ProductForCreationDTO product)
    {
        var query = @"INSERT INTO Products(Name, ModelYear, Price, BrandId, CategoryId)
                    VALUES(@name, @modelYear, @price, @brandId, @categoryId);
                    SELECT CAST(SCOPE_IDENTITY() AS int)";

        using var connection = _context.CreateConnection();

        var queryParameters = new DynamicParameters();
        queryParameters.Add("name", product.Name, DbType.String);
        queryParameters.Add("modelYear", product.ModelYear, DbType.Int16);
        queryParameters.Add("price", product.Price, DbType.Decimal);
        queryParameters.Add("brandId", product.BrandId, DbType.Int32);
        queryParameters.Add("categoryId", product.CategoryId, DbType.Int32);

        var id = await connection.QuerySingleAsync<int>(query, queryParameters);

        var createdProduct = new Product
        {
            Id = id,
            Name = product.Name,
            ModelYear = product.ModelYear,
            Price = product.Price,
            BrandId = product.BrandId,
            CategoryId = product.CategoryId
        };

        return createdProduct;
    }
    public async Task UpdateProductAsync(int id, ProductForUpdateDTO product)
    {
        var query = @"UPDATE Products
                    SET Name = @name, Price = @price
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        var queryParameters = new DynamicParameters();
        queryParameters.Add("Id", id, DbType.Int32);
        queryParameters.Add("name", product.Name, DbType.String);
        queryParameters.Add("price", product.Price, DbType.Decimal);

        await connection.ExecuteAsync(query, queryParameters);
    }
    public async Task DeleteProductAsync(int id)
    {
        var query = @"DELETE FROM Products
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { id });
    }
}
