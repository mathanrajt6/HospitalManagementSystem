using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HMSUserAPI.Models.DTOs
{
    public class DoctorUpdateDTO : UserUpdateDTO
    {
        [Required(ErrorMessage = "The ConsultingFees field is required")]
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
    }
}
