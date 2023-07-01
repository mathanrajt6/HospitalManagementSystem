using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;

namespace HMSUserAPI.Services
{
    public class AdminService : IAdminAction
    {
        private readonly IRepo<User, int> _repo;

        public AdminService(IRepo<User,int> repo)
        {
            _repo = repo;
        }

        public async Task<User?> ChangeApproveStatus(DoctorApproveDTO doctorApproveDTO)
        {
            var user = await _repo.Get(doctorApproveDTO.ID);
            if(user != null && user.UserDetail!= null && user.UserDetail.Doctor!= null && user.Role == "doctor")
            {
                user.UserDetail.Doctor.ApprovedStatus = doctorApproveDTO.Status;
                var result = await _repo.Update(user);
                return result;
            }
            return null;
        }

        public async Task<List<DoctorDTO>?> GetAllDoctor()
        {
            var users = await _repo.GetAll();
            if(users != null)
            {
                var doctors = users.Where(x => x.Role == "doctor" && x.UserDetail?.Patient == null).Select(u=> new DoctorDTO(u.UserDetail)).ToList();
                return doctors;
            }
            return null;
           
        }

        public async Task<List<DoctorDTO>?> GetAllDoctorBasedOnStatus(DoctorFilterDTO doctorFilterDTO)
        {
            var users = await _repo.GetAll();
            if(users != null)
            {
                var doctors = users.Where(x => x.Role == "doctor" && x.UserDetail?.Patient == null && x.UserDetail?.Doctor?.ApprovedStatus == doctorFilterDTO.Status).Select(u => new DoctorDTO(u.UserDetail, u.Email)).ToList();
                return doctors;
            }
            return null;

        }

        public async Task<UserDetailDTO?> GetUserDetailDetail(UserDTO userDTO)
        {
            var user = await _repo.Get(userDTO.Id);
            if(user != null && user.UserDetail!= null && user.Role == "admin")
            {
                return new UserDetailDTO(user.UserDetail, user.Email??"");
            }
            return null;
        }

        public async Task<UserUpdateDTO?> UpdateAdminDetails(UserUpdateDTO userUpdateDTO)
        {
            var user = await _repo.Get(userUpdateDTO.Id);
            if(user != null && user.UserDetail != null)
            {
                user.UserDetail.Address = userUpdateDTO.Address;
                user.UserDetail.DateOfBirth = userUpdateDTO.DateOfBirth;
                user.UserDetail.PhoneNUmber = userUpdateDTO.Phone;
                await _repo.Update(user);
                return userUpdateDTO;
            }
            return null;
        }
    }
}
