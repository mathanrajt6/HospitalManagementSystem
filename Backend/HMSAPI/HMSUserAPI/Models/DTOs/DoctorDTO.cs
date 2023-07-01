using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HMSUserAPI.Models.DTOs
{
    public class DoctorDTO : UserDetailDTO,IEntity
    {
        public DoctorDTO()
        {
            
        }

        public DoctorDTO(UserDetail userDetail): base(userDetail)
        {
         
            Doctor = userDetail.Doctor;

        }
        public DoctorDTO(UserDetail userDetail,string email) : base(userDetail,email)
        {
            Doctor = userDetail.Doctor;
        }

        public Doctor? Doctor { get; set; }
    }
}
