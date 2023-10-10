using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace ManageFileBE.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), NotNull]
        public string Username { get; set; }
        [MaxLength(50), NotNull]
        public string FullName { get; set; }
        [MaxLength(50), NotNull]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Role { get; set; }
        public byte[] PasswordSalt { get; internal set; }
        public byte[] PasswordHash { get; internal set; }
        public string CurrentToken { get; internal set; }
    }
}
