using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMSUserAPI.Models.DTOs
{
    public class PatientDTO : UserDetailDTO,IEntity
    {
        public PatientDTO()
        {

        }

        public PatientDTO(UserDetail userDetail):base(userDetail)
        { 
            Patient = userDetail.Patient;

        }
        public PatientDTO(UserDetail userDetail, string email) : base(userDetail,email) 
        {
            Patient = userDetail.Patient;
        }

        public Patient? Patient { get; set; }
    }
}
