using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models.DTOs
{
    public class PatientUpdateDTO : UserUpdateDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Emergency COntact name Group should be less than 50 characters")]
        public string? EmergencyContactName { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Emergency Contact Phone Number should have only 10 digits")]
        public string? EmergencyContactPhone { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Emergency Contact Relation should be less than 50 characters")]
        public string? BloodGroup { get; set; }
    }
}
