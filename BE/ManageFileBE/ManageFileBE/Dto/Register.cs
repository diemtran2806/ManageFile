﻿using System.ComponentModel.DataAnnotations;

namespace ManageFileBE.Dto
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } = "User";

    }
}
