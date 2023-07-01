using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;

namespace HMSUserAPI.Interfaces
{
    public interface IDoctorAction 
    {
        public Task<List<PatientDTO>?> GetAllPatient();
        public Task<UserDTO?> DoctorRegister(User user);
        public Task<DoctorFilterDTO?> ToggleActive(DoctorFilterDTO  doctorFilterDTO);
        public Task<DoctorUpdateDTO?> UpdateDoctorDetails(DoctorUpdateDTO doctorUpdateDTO);
        public Task<DoctorDTO?> GetDoctorDetails(UserDTO userDTO);
    }
}
