using System.IdentityModel.Tokens.Jwt;
using System.Text;
using InventorySystem.API.DTOs;
using InventorySystem.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventorySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _appConfig;

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var loginResult = await this._signInManager
                .PasswordSignInAsync(loginDTO.Username, loginDTO.Password, loginDTO.RememberMe, false);

            if (!loginResult.Succeeded) return BadRequest("Username/Password invalid.");

            var user = await this._userManager.FindByEmailAsync(loginDTO.Username);

            if (user == null) return NotFound();

            var issuer = this._appConfig["JWT:Issuer"];
            var audience = this._appConfig["JWT:Audience"];
            var key = this._appConfig["JWT:Key"];

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var theKey = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    issuer, 
                    audience, 
                    null, 
                    expires: DateTime.Now.AddMinutes(30), 
                    signingCredentials: creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] RegisterUserDTO registerDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ApplicationUser user = new ApplicationUser
            {
                UserName = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                Gender = registerDTO.Gender
            };

            // var newUser = await this._userManager.CreateAsync(user, userDTO.Password);
            // if (newUser.Succeeded)
            //     return user;

            return Ok();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}