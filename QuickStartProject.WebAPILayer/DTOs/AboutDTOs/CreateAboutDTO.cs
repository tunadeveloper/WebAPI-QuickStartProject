namespace QuickStartProject.WebAPILayer.DTOs.AboutDTOs;

public class CreateAboutDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Images { get; set; }
}
