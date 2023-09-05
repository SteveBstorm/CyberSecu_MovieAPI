using System.ComponentModel.DataAnnotations;

namespace CyberSecu_MovieAPI.DTOs
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
