using System.ComponentModel.DataAnnotations;

namespace HMSUserAPI.Models.DTOs
{
    public class UserPasswordUpdateDTO : IEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string? NewPassword { get; set; }
    }
}
