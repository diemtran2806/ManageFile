using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace ManageFileBE.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TokenExpirationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public TokenExpirationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Lấy token từ yêu cầu HTTP
            /*if (context.Request.Path.StartsWithSegments(new PathString("/api/file")))
            {

                var accessToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                // Kiểm tra thời gian hết hạn của token
                if (IsTokenExpired(accessToken))
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Token has expired.");
                    return;
                }

            }*/
            // Tiếp tục xử lý yêu cầu nếu token còn hạn
            await _next(context);
        }

        private bool IsTokenExpired(string token)
        {
            try
            {
                string secretKey = _configuration["Jwt:Key"];
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                };
                SecurityToken validatedToken;
                tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                // Kiểm tra thời gian hết hạn của token
                var jwtToken = (JwtSecurityToken)validatedToken;
                var expiration = jwtToken.ValidTo;
                var now = DateTime.UtcNow;
                return now > expiration;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TokenExpirationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenExpirationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenExpirationMiddleware>();
        }
    }
}
