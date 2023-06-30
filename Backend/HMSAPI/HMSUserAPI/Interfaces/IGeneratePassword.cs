using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;

namespace HMSUserAPI.Interfaces
{
    public interface IGeneratePassword
    {
        public string GeneratePassword(User user);

    }
}
