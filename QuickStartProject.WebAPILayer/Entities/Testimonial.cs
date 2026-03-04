using QuickStartProject.WebAPILayer.Entities.Common;

namespace QuickStartProject.WebAPILayer.Entities;

public class Testimonial : BaseEntity
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string ImageUrl { get; set; }
    public string Content { get; set; }
}
