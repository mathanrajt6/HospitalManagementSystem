using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models.DTOs
{
    public class UserDTO : IEntity
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email should be valid")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [RegularExpression("^(doctor|patient|admin)$", ErrorMessage = "The Role field must be 'doctor', 'patient', or 'admin'")]
        public string? Role { get; set; }
        public string? Token { get; set; }
        [RegularExpression("^(approved|un-approved|pending)$", ErrorMessage = "The ApprovedStatus field must be either 'approved', 'un-approved', or 'pending'")]
        public string? Status { get; set; }

    }
}
