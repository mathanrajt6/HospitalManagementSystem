using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;
using HMSUserAPI.Models.Error;
using System.Security.Cryptography;
using System.Text;

namespace HMSUserAPI.Services
{
    public class PatientService : IPatientAction
    {

        private readonly IRepo<User, int> _repo;
        private readonly ITokenGenerate _tokenGenerate;
        private readonly IGeneratePassword _generatePassword;

        public PatientService(IRepo<User, int> repo, ITokenGenerate tokenGenerate, IGeneratePassword generatePassword)
        {
            _repo = repo;
            _tokenGenerate = tokenGenerate;
            _generatePassword = generatePassword;
        }

        public async Task<List<DoctorDTO>?> GetAllDoctor()
        {
            var users = await _repo.GetAll();
            if (users != null)
            {
                var doctors = users.Where(x => x.Role == "doctor" && x.UserDetail?.Patient == null ).Select(u => new DoctorDTO(u.UserDetail)).ToList();
                return doctors;
            }
            return  null;
        }


        public async  Task<List<DoctorDTO>?> GetAllDoctorBasedOnFilters(DoctorFilterDTO doctorFilterDTO)
        {
            var users = await _repo.GetAll();
            if (users != null)
            {

                var doctors = users.Where(x => x.Role == "doctor" && x.UserDetail?.Patient == null).Select(u => new DoctorDTO(u.UserDetail,u.Email)).ToList();
                if (doctorFilterDTO.Active != null && doctorFilterDTO.HighToLow != null )
                {
                    if(doctorFilterDTO.HighToLow == "yes")
                        return doctors.Where (x => x.Doctor?.Active == doctorFilterDTO.Active).OrderByDescending(x => x.Doctor?.ConsultingFees).ToList();
                    return doctors.Where(x => x.Doctor?.Active == doctorFilterDTO.Active).OrderBy(x => x.Doctor?.ConsultingFees).ToList();
                }
                if(doctorFilterDTO.HighToLow != null)
                {
                    if(doctorFilterDTO.HighToLow == "yes")
                        return doctors.OrderByDescending(x => x.Doctor?.ConsultingFees).ToList();
                    return doctors.OrderBy(x => x.Doctor?.ConsultingFees).ToList();
                }
                if(doctorFilterDTO.Active != null)
                {
                    return doctors.Where(x => x.Doctor?.Active == doctorFilterDTO.Active).ToList();
                }
                return doctors;
            }
            return null;
        }

        public async Task<PatientDTO?> GetPatientDetail(UserDTO userDTO)
        {
            var user = await _repo.Get(userDTO.Id);
            if (user != null && user.UserDetail != null && user.Role == "patient" && user.UserDetail.Patient!= null)
            {
                return new PatientDTO(user.UserDetail, user.Email ?? "");
            }
            return null;
        }

        public async  Task<UserDTO?> PatientRegister(User user)
        {
            var users = await _repo.GetAll();
            if (users == null)
            {
                throw new UserException(ResponseMsg.Messages[8]);
            }

            if (user != null && user.UserDetail != null && user.UserDetail.Patient != null)
            {
                var userExists = users.FirstOrDefault(u => u.Email == user.Email);
                if (userExists != null)
                {
                    throw new UserException(ResponseMsg.Messages[5]);
                }
                var hmac = new HMACSHA256();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_generatePassword.GeneratePassword(user)));
                user.HashKey = hmac.Key;
                user.Role = "patient";
                if (user.UserDetail?.Doctor != null)
                    user.UserDetail.Doctor = null;
                var registeredUser = await _repo.Add(user);
                if (registeredUser != null)
                {
                    return new UserDTO
                    {
                        Id = registeredUser.Id,
                        Email = registeredUser.Email,
                        Token = await _tokenGenerate.GenerateJSONWebToken(registeredUser),
                        Role = registeredUser.Role

                    };
                }
                return null;
            }
            throw new UserException(ResponseMsg.Messages[4]); ;
        }

        public async Task<PatientUpdateDTO?> UpdatePatientDetails(PatientUpdateDTO patientUpdateDTO)
        {
            var user = await _repo.Get(patientUpdateDTO.Id);
            if (user != null && user.UserDetail != null && user.UserDetail.Patient != null)
            {
                user.UserDetail.Address = patientUpdateDTO.Address;
                user.UserDetail.DateOfBirth = patientUpdateDTO.DateOfBirth;
                user.UserDetail.PhoneNUmber = patientUpdateDTO.Phone;
                user.UserDetail.Patient.EmergencyContactName = patientUpdateDTO.EmergencyContactName;
                user.UserDetail.Patient.EmergencyContactPhone = patientUpdateDTO.EmergencyContactPhone;
                await _repo.Update(user);
                return patientUpdateDTO;
            }
            return null;
        }
    }
}
