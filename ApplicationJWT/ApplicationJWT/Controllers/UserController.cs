using ApplicationJWT.Models;
using ApplicationJWT.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationJWT.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public string getAdminI()
        {
            return "Hello admin";
        }
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public string getUser()
        {
            return "Hello user";
        }
        
    }
}
