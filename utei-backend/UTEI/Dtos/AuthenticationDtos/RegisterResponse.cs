using UTEI.Models.AuthenticationModel;

namespace UTEI.Dtos.AuthenticationDtos
{
    public class RegisterResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
        public ApplicationUser User { get; set; }
    }
}
