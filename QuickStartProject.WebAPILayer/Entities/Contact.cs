using QuickStartProject.WebAPILayer.Entities.Common;

namespace QuickStartProject.WebAPILayer.Entities;

public class Contact : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
