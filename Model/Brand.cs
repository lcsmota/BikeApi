namespace BikeApi.Model;

public class Brand : EntityBase
{
    public List<Product> Products { get; set; } = new();
}
