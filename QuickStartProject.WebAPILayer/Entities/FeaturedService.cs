using QuickStartProject.WebAPILayer.Entities.Common;

namespace QuickStartProject.WebAPILayer.Entities;

public class FeaturedService : BaseEntity
{
    public string Icon { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
