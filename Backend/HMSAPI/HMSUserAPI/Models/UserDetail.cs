using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HMSUserAPI.Models
{
    public class UserDetail : IEntity
    {
        [Key]
        public int UserDetailID { get; set; }
        [ForeignKey("UserDetailID")]
        [JsonIgnore]
        public User? User { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]{1,50}$", ErrorMessage = "First Name should have only alphabet and less than 50 character")]
        public string? FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]{1,50}$", ErrorMessage = "Last Name should have only alphabet and less than 50 character")]
        public string? LastName { get; set; }

        [Range(18, 150,ErrorMessage ="Age should be between 18 and 150")]
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

        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone Number should have only 10 digits")]
        public string?  PhoneNUmber { get; set; }

        [Required]
        [MaxLength(250,ErrorMessage ="Address should be less than 250 characters")]
        public string? Address { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Gender should be less than 50 characters")]
        public string? Gender { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }


    }
}
