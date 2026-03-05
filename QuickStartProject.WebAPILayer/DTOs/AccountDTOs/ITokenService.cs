using QuickStartProject.WebAPILayer.Entities;

namespace QuickStartProject.WebAPILayer.DTOs.AccountDTOs
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
