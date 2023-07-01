using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models.DTOs
{
    public class UserUpdateDTO :IEntity
    {
        public int Id { get; set; }
        [Range(18, 150, ErrorMessage = "Age should be between 18 and 150")]
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
        public DateTime DateOfBirth { get; set; }

        [MaxLength(250, ErrorMessage = "Address should be less than 250 characters")]
        public string? Address { get; set; }
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone Number should have only 10 digits")]
        public string? Phone { get; set; }

    }
}
