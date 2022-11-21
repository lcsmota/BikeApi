namespace BikeApi.Model;

public class Product : EntityBase
{
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
    public short ModelYear { get; set; }
    public decimal Price { get; set; }
}
