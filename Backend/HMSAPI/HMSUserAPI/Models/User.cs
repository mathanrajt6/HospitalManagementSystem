using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email should be valid")]
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? HashKey { get; set; }
        [Required]
        [RegularExpression("^(doctor|patient|admin)$", ErrorMessage = "The Role field must be 'doctor', 'patient', or 'admin'")]
        public string? Role { get; set; }
        public UserDetail? UserDetail { get; set; }
    }
}
