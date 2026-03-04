using QuickStartProject.WebAPILayer.Entities.Common;

namespace QuickStartProject.WebAPILayer.Entities;

public class Message : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}
