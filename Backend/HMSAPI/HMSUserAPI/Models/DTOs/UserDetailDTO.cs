using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMSUserAPI.Models.DTOs
{
    public class UserDetailDTO
    {
        public UserDetailDTO()
        {
            
        }

        public UserDetailDTO(UserDetail userDetail) 
        {
            UserDetailID = userDetail.UserDetailID;
            FirstName = userDetail.FirstName;
            LastName = userDetail.LastName;
            DateOfBirth = userDetail.DateOfBirth;
            PhoneNUmber = userDetail.PhoneNUmber;
            Address = userDetail.Address;
            Gender = userDetail.Gender;
            DateOfBirth = userDetail.DateOfBirth;

        }
        public UserDetailDTO(UserDetail userDetail, string email) : this(userDetail)
        {
            Email = email;
        }
        public int UserDetailID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

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

        public string? PhoneNUmber { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }
    }
}
