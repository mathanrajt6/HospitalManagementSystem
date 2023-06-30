using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HMSUserAPI.Models
{
    public class UserDetail
    {
        [Key]
        public int UserDetailID { get; set; }
        [ForeignKey("UserDetailID")]
        [JsonIgnore]
        public User? User { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int age = now.Year - DateOfBirth.Year;
                if (now < DateOfBirth.AddYears(age))
                    age--;
                return age;
            }
        }


        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public string?  PhoneNUmber { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }


    }
}
