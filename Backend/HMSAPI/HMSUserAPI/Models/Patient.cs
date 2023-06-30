using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HMSUserAPI.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        [JsonIgnore]
        public UserDetail? UserDetail { get; set; }

        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }


    }
}
