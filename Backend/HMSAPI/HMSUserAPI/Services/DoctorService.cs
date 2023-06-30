using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;
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
            if (users == null)
            {
                throw new UserException("Users not Found");
            }

            if (user != null)
            {
                var userExists = users.FirstOrDefault(u => u.Email == user.Email);
                if (userExists != null)
                {
                    throw new UserException("User Already Exists");
                }
                var hmac = new HMACSHA256();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_generatePassword.GeneratePassword(user)));
                user.HashKey = hmac.Key;
                user.Role = "doctor";
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
            throw new UserException("User can't be null");
        }

        public async Task<List<PatientDTO>?> GetAllPatient()
        {
            var users = await _repo.GetAll();
            if(users != null)
            {
                  return users.Where(x => x.Role == "patient" && x.UserDetail != null && x.UserDetail?.Doctor == null).Select(u => new PatientDTO(u.UserDetail)).ToList();
            }
            return null;
        }


    }
}
