namespace QuickStartProject.WebAPILayer.DTOs.PricingDTOs;

public class CreatePricingDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Period { get; set; }
    public bool IsFeatured { get; set; }
    public List<string> Features { get; set; }
}
