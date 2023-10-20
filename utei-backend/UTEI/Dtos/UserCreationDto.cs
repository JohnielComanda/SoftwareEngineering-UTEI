using System.ComponentModel.DataAnnotations;
namespace UTEI.Dtos
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "User Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
