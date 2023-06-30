using HMSUserAPI.Interfaces;
using HMSUserAPI.Models;

namespace HMSUserAPI.Services
{
    public class GeneratePasswordService : IGeneratePassword
    {
        public string GeneratePassword(User user)
        {
            if(user!=null && user.UserDetail!=null && user.UserDetail.FirstName != null )
            {
               return user.UserDetail.FirstName.Substring(0, 4) + user.UserDetail.DateOfBirth.Year;
             
            }
            return "ABCD1234";
        }
    }
}
