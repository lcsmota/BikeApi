namespace BikeApi.Model;

public class Category : EntityBase
{
    public List<Product> Products { get; set; } = new();
}
