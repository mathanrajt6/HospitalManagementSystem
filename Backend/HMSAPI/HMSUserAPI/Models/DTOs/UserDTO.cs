namespace HMSUserAPI.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }

        public bool? Status { get; set; }

    }
}
