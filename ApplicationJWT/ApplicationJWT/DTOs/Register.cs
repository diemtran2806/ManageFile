﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationJWT.DTOs
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; } = "User";
    }
}
