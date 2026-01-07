using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Model_;
using BLL_.InterFace;

namespace AuthencationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly INguoiDung _nguoiDungService;
        public AccountController(IConfiguration configuration, INguoiDung nguoiDungService)
        {
            config = configuration;
            _nguoiDungService = nguoiDungService;
        }

        private static ConcurrentDictionary<string, string> Accounts { get; set; } = new ConcurrentDictionary<string, string>();
        [HttpPost("login")]
        public async Task<IActionResult> Get([FromForm] string email, [FromForm] string password)
        {
            await Task.Delay(500);
            NguoiDung nguoiDung = new NguoiDung(email,password);


            var user = _nguoiDungService.GetbyMkTKTaiKhoan(nguoiDung);

            
            if (user == null || string.IsNullOrEmpty(user.email))
            {
                return Unauthorized("Email hoặc mật khẩu không đúng");
            }

            var token = GenerateToken(user.email);
            return Ok(new { Token = token });
        }


        private string GenerateToken(string email)
        {
            var key =   Encoding.UTF8.GetBytes(config["Authentication:Key"]!);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {new Claim(ClaimTypes.Email, email!)};
            var token = new JwtSecurityToken(
                issuer: config["Authentication:Issuer"],
                audience: config["Authentication:Audience"],
                claims: claims,
                expires: null,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("register/{nd}")]
        public async Task<IActionResult> resgister(NguoiDung nd)
        {
            await Task.Delay(500); // Simulate async operation
            return NotFound("Chua xong");
        }


    }
}
