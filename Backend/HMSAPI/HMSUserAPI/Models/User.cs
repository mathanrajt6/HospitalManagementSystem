using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? HashKey { get; set; }
        [Required]
        public string? Role { get; set; }
        public UserDetail? UserDetail { get; set; }
    }
}
