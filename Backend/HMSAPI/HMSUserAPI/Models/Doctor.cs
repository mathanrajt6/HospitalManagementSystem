using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HMSUserAPI.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        [ForeignKey("DoctorID")]
        [JsonIgnore]
        public UserDetail? UserDetail { get; set; }
        public int ConsultingFees { get; set; }
        public string? Specialization { get; set; }
        public int YearOfExperience { get; set; }
        public bool ApprovedStatus { get; set; }
        public bool Active { get; set; }
    }
}
