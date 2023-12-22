using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace UTEI.Dtos
{
    /// <summary>
    /// This dto is for user credentials to be authenticated
    /// </summary>
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email address is required.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
