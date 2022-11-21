using System.Data;
using BikeApi.Context;
using BikeApi.Contracts;
using BikeApi.Model;
using Dapper;

namespace BikeApi.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly DapperContext _context;
    public CategoryRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var query = @"SELECT Id, Name
                    FROM Categories
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        var category = await connection.QuerySingleOrDefaultAsync<Category>(query, new { id });

        return category;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var query = @"SELECT Id, Name
                    FROM Categories";

        using var connection = _context.CreateConnection();

        var categorys = await connection.QueryAsync<Category>(query);

        return categorys;
    }
    public async Task<Category> CreateCategoryAsync(Category category)
    {
        var query = @"INSERT INTO Categories(Name)
                    VALUES(@name);
                    SELECT CAST(SCOPE_IDENTITY() AS int)";

        using var connection = _context.CreateConnection();

        var queryParameters = new DynamicParameters();
        queryParameters.Add("name", category.Name, DbType.String);

        var id = await connection.QuerySingleAsync<int>(query, queryParameters);

        var createdCategory = new Category
        {
            Id = id,
            Name = category.Name
        };

        return createdCategory;
    }
    public async Task UpdateCategoryAsync(int id, Category category)
    {
        var query = @"UPDATE Categories
                    SET Name = @name
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        var queryParameters = new DynamicParameters();
        queryParameters.Add("Id", id, DbType.Int32);
        queryParameters.Add("name", category.Name, DbType.String);

        await connection.ExecuteAsync(query, queryParameters);
    }
    public async Task DeleteCategoryAsync(int id)
    {
        var query = @"DELETE FROM Categories
                    WHERE Id = @Id";

        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(query, new { id });
    }
}
