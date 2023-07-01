using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace HMSUserAPI.Models
{
    public class Doctor : IEntity
    {
        [Key]
        public int DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        [JsonIgnore]
        public UserDetail? UserDetail { get; set; }
        [Required(ErrorMessage ="The ConsultingFees field is required")]
        [Range(100, 10000, ErrorMessage = "Consulting Fees should be between 100 and 10000")]
        [DefaultValue(0)]
        public int ConsultingFees { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Specialization should be less than 100 characters")]
        public string? Specialization { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Year of Experience should be between 0 and 100")]
        [DefaultValue(0)]
        public int YearOfExperience { get; set; }

        [Required]
        [RegularExpression("^(approved|un-approved|pending)$", ErrorMessage = "The ApprovedStatus field must be either 'approved', 'un-approved', or 'pending'")]
        public string? ApprovedStatus { get; set; }
        [Required]
        [RegularExpression("^(active|in-active)$", ErrorMessage = "The Active field must be 'active' or 'in-active'")]
        public string? Active { get; set; }
    }

    public enum DoctorStatus
    {
        Approved,
        rejected,
        pending
    }
}
