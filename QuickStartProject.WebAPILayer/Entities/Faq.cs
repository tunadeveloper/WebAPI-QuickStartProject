using QuickStartProject.WebAPILayer.Entities.Common;

namespace QuickStartProject.WebAPILayer.Entities;

public class Faq : BaseEntity
{
    public string Question { get; set; }
    public string Answer { get; set; }
}
