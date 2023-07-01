using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models.DTOs
{
    public class DoctorFilterDTO :IEntity
    {
        public int Id { get; set; }

        [RegularExpression("^(yes|no)$", ErrorMessage = "The Active field must be 'yes' or 'no'")]
        public string? HighToLow { get; set; }

        [RegularExpression("^(active|in-active)$", ErrorMessage = "The Active field must be 'active' or 'in-active'")]
        public string? Active { get; set; }
        [RegularExpression("^(approved|un-approved|pending)$", ErrorMessage = "The ApprovedStatus field must be either 'approved', 'un-approved', or 'pending'")]
        public string? Status { get; set; }
    }
}
