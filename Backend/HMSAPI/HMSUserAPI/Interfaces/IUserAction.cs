using HMSUserAPI.Models.DTOs;

namespace HMSUserAPI.Interfaces
{
    public interface IUserAction
    {
        public Task<UserDTO?> Login(UserDTO userDTO);
        public Task<UserPasswordUpdateDTO?> PasswordUpdate(UserPasswordUpdateDTO userPasswordUpdateDTO);
    }
}
