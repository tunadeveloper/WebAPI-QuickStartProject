using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.AccountDTOs;
using QuickStartProject.WebAPILayer.Entities;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user,dto.Password))
            {
                return Ok(new { Token = _tokenService.CreateToken(user) });
            }

            return Unauthorized("Giriş yapılmadı");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var appUser = new AppUser
            {
                UserName = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(appUser, dto.Password);
            return result.Succeeded ? Ok("Kayıt Başarılı") : BadRequest(result.Errors);
        }
    }
}
