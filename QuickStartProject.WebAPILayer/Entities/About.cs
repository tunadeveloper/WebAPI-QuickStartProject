using QuickStartProject.WebAPILayer.Entities.Common;

namespace QuickStartProject.WebAPILayer.Entities;

public class About: BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Images { get; set; }
}
