using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;

namespace HMSUserAPI.Interfaces
{
    public interface IAdminAction
    {
        public Task<User?> ChangeApproveStatus(DoctorApproveDTO doctorApproveDTO);
        public Task<List<DoctorDTO>?> GetAllDoctorBasedOnStatus(DoctorFilterDTO doctorFilterDTO);
        public Task<List<DoctorDTO>?> GetAllDoctor();

    }
}
