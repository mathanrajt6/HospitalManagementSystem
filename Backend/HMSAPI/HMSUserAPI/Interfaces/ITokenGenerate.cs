using HMSUserAPI.Models;
using HMSUserAPI.Models.DTOs;

namespace HMSUserAPI.Interfaces
{
    public interface ITokenGenerate
    {
        public Task<string> GenerateJSONWebToken(User user);

    }
}
