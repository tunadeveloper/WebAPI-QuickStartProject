using Microsoft.AspNetCore.Identity;

namespace QuickStartProject.WebAPILayer.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class AppRole : IdentityRole<int>
    {
    }
}
