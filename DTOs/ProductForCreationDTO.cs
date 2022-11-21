namespace BikeApi.DTOs;

public class ProductForCreationDTO
{
    public string Name { get; set; } = string.Empty;
    public short ModelYear { get; set; }
    public decimal Price { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }

}
