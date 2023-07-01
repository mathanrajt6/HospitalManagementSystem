using HMSUserAPI.Exceptions;
using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace HMSUserAPI.Services
{
    public class UserService : IUserAction
    {
        private readonly IRepo<User, int> _repo;
        private readonly ITokenGenerate _tokenGenerate;
        private readonly IGeneratePassword _generatePassword;

        public UserService(IRepo<User, int> repo, ITokenGenerate tokenGenerate, IGeneratePassword generatePassword)
        {
            _repo = repo;
            _tokenGenerate = tokenGenerate;
            _generatePassword = generatePassword;
        }


        public async Task<UserDTO?> Login(UserDTO userDTO)
        {
            var users = await _repo.GetAll();
            if (users == null)
            {
                throw new UserException("Users not Found");
            }
            var user = users.FirstOrDefault(u => u.Email == userDTO.Email);
            if (user != null && userDTO.Email != null && userDTO.Password != null && user.PasswordHash != null && user.HashKey != null)
            {
                var hmac = new HMACSHA256(user.HashKey);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (user.PasswordHash != null && computedHash[i] != user.PasswordHash[i])
                        return null;
                }
                UserDTO returnUser = new UserDTO();
                if (user.Role?.ToLower() == "doctor")
                {
                    returnUser.Status = user.UserDetail?.Doctor?.ApprovedStatus;
                }
                returnUser.Email = user.Email;
                returnUser.Role = user.Role;
                returnUser.Id = user.Id;
                returnUser.Token = await _tokenGenerate.GenerateJSONWebToken(user);
                return returnUser;
            }
            throw new UserException("User not Found");

        }

        public async Task<UserPasswordUpdateDTO?> PasswordUpdate(UserPasswordUpdateDTO userPasswordUpdateDTO)
        {
            var user = await _repo.Get(userPasswordUpdateDTO.ID);
            if(userPasswordUpdateDTO.NewPassword == null)
            {
                throw new UserException("Password can't be empty"); 
            }
            if (user != null && userPasswordUpdateDTO != null)
            {
                var hmac = new HMACSHA256();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPasswordUpdateDTO.NewPassword));
                user.HashKey = hmac.Key;
                var result = await _repo.Update(user);
                if (result != null)
                {
                    return userPasswordUpdateDTO;
                }
            }
            return null;
        }
    }
}
