using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;
using HMSUserAPI.Models.Error;
using System.Security.Cryptography;
using System.Text;

namespace HMSUserAPI.Services
{
    public class DoctorService : IDoctorAction
    {

        private readonly IRepo<User, int> _repo;
        private readonly ITokenGenerate _tokenGenerate;
        private readonly IGeneratePassword _generatePassword;

        public DoctorService(IRepo<User, int> repo, ITokenGenerate tokenGenerate, IGeneratePassword generatePassword)
        {
            _repo = repo;
            _tokenGenerate = tokenGenerate;
            _generatePassword = generatePassword;
        }

        public async Task<UserDTO?> DoctorRegister(User user)
        {
            var users = await _repo.GetAll();
            

            if (user != null && user.UserDetail != null && user.UserDetail.Doctor != null)
            {
                var userExists = users.FirstOrDefault(u => u.Email == user.Email);
                if (userExists != null)
                {
                    throw new UserException(ResponseMsg.Messages[5]);
                }
                var hmac = new HMACSHA256();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_generatePassword.GeneratePassword(user)));
                user.HashKey = hmac.Key;
                user.Role = "doctor";
                user.UserDetail.Doctor.ApprovedStatus = "pending";
                user.UserDetail.Doctor.Active = "in-active";
                if(user.UserDetail?.Patient != null)
                    user.UserDetail.Patient = null;
                var registeredUser = await _repo.Add(user);
                if(registeredUser != null)
                {
                    return new UserDTO
                    {
                        Id = registeredUser.Id,
                        Email = registeredUser.Email,
                        Token = await _tokenGenerate.GenerateJSONWebToken(registeredUser),
                        Status = registeredUser.UserDetail?.Doctor?.ApprovedStatus,
                        Role = registeredUser.Role
                    };
                }
                return null;
            }
            throw new UserException(ResponseMsg.Messages[3]);
        }

        public async Task<List<PatientDTO>?> GetAllPatient()
        {
            var users = await _repo.GetAll();
            if(users != null)
            {
                  return users.Where(x => x.Role == "patient" && x.UserDetail != null && x.UserDetail?.Doctor == null).Select(u => new PatientDTO(u.UserDetail,u.Email)).ToList();
            }
            return null;
        }

        public async Task<DoctorDTO?> GetDoctorDetails(UserDTO userDTO)
        {
            var user = await _repo.Get(userDTO.Id);
            if (user != null && user.UserDetail != null && user.Role == "doctor" && user.UserDetail.Doctor!= null)
            {
                return new DoctorDTO(user.UserDetail, user.Email ?? "");
            }
            return null;
        }

        public async Task<DoctorFilterDTO?> ToggleActive(DoctorFilterDTO doctorFilterDTO)
        {

            var user = await _repo.Get(doctorFilterDTO.Id);
             if(user != null && user.UserDetail!= null && user.UserDetail.Doctor != null)
            {
                if (user.UserDetail.Doctor.Active == "in-active")
                    user.UserDetail.Doctor.Active = "active";
                else
                    user.UserDetail.Doctor.Active = "in-active";
                await _repo.Update(user);
                return new DoctorFilterDTO
                {
                    Id = user.Id,
                    Active = user.UserDetail.Doctor?.Active,
                };
            }
            return null;
        }

        public async Task<DoctorUpdateDTO?> UpdateDoctorDetails(DoctorUpdateDTO doctorUpdateDTO)
        {
            var user = await _repo.Get(doctorUpdateDTO.Id);
            if (user != null && user.UserDetail != null && user.UserDetail.Doctor!= null)
            {
                user.UserDetail.Address = doctorUpdateDTO.Address;
                user.UserDetail.DateOfBirth = doctorUpdateDTO.DateOfBirth;
                user.UserDetail.PhoneNUmber = doctorUpdateDTO.Phone;
                user.UserDetail.Doctor.ConsultingFees = doctorUpdateDTO.ConsultingFees;
                user.UserDetail.Doctor.YearOfExperience = doctorUpdateDTO.YearOfExperience;
                user.UserDetail.Doctor.Specialization = doctorUpdateDTO.Specialization;
                await _repo.Update(user);
                return doctorUpdateDTO;

            }
            return null;
        }
    }
}
