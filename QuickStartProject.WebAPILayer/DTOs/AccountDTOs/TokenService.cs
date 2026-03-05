using Microsoft.IdentityModel.Tokens;
using QuickStartProject.WebAPILayer.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuickStartProject.WebAPILayer.DTOs.AccountDTOs
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration _configration;

        public TokenService(IConfiguration configration)
        {
            _configration = configration;
        }

        public string CreateToken(AppUser appUser)
        {
            var jwtSettings = _configration.GetSection("JwtSettings");
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim("Name", appUser.Name),
                new Claim("Surname", appUser.Surname)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryInMinutes"])),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
