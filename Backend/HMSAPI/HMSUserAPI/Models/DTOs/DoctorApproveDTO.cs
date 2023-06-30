using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models.DTOs
{
    public class DoctorApproveDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
