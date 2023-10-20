using System.ComponentModel.DataAnnotations;

namespace UTEI.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "User Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
