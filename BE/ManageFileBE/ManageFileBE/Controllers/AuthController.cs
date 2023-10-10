
using ManageFileBE.Dto;
using ManageFileBE.Models;
using ManageFileBE.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ManageFileBE.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        
        public AuthController(IConfiguration config, IUserService userService)
        {
            _configuration = config;
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult RegisterAccount([FromBody] Register account)
        {
            if(account.Password == account.ConfirmPassword)
            {
                bool isExists = _userService.IsExists(account.Username);
                if (!isExists)
                {
                    bool isSaved = _userService.SaveUser(account);
                    if (isSaved == true)
                    {
                        return Ok();
                    }
                    else
                        return StatusCode(500, new { message = "Internal Server Error" });
                }
                else
                {
                    return BadRequest(new { message = "Account already exists" });
                }
            }
            else
            {
                return BadRequest(new { message = "Password don't match!" });
            }
        }

      
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login account)
        {
            var user = _userService.GetAllUser().Where(x => x.Username == account.Username).FirstOrDefault();

            if (user == null)
            {
                return BadRequest("Username Or Password Was Invalid");
            }

            var match = CheckPassword(account.Password, user);

            if (!match)
            {
                return BadRequest("Username Or Password Was Invalid");
            }
            var token = GeneratorToken(user);
            String strToken = new JwtSecurityTokenHandler().WriteToken(token);
           
            user.CurrentToken = strToken;
            _userService.UpdateUser(user.Id, user);
            return Ok(new LoginResponse
            {
                Username = user.Username,
                Email = user.Email,
                Token = strToken,
            });

        }
        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] string refreshToken)
        {
            Users user = _userService.FingByToken(refreshToken); 
            if (user != null)
            {
                var token = GeneratorToken(user);
                user.CurrentToken = token;
                _userService.UpdateUser(user.Id, user);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            return BadRequest("Token is not valid");
        }
        private bool CheckPassword(string password, Users user)
        {
            bool result;
            using (HMACSHA512? hmac = new HMACSHA512(user.PasswordSalt))
            {
                var compute = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                result = compute.SequenceEqual(user.PasswordHash);
            }
            return result;
        }
        private dynamic GeneratorToken(Users user)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserName", user.Username),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return token;
        }

        public ClaimsPrincipal GetPrincipalFromExpriedToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                ValidateLifetime = false,

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var pricipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecutityToken = securityToken as JwtSecurityToken;
            if (jwtSecutityToken == null || !jwtSecutityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid Token");
            return pricipal;
        }
    }
}
