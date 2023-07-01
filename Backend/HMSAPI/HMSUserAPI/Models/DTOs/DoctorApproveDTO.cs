using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models.DTOs
{
    public class DoctorApproveDTO : IEntity
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [RegularExpression("^(approved|un-approved|pending)$", ErrorMessage = "The ApprovedStatus field must be either 'approved', 'un-approved', or 'pending'")]
        public string? Status { get; set; }
    }
}
