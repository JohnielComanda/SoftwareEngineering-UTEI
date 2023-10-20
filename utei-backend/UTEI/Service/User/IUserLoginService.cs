using UTEI.Dtos;

namespace UTEI.Service.User
{
    public interface IUserLoginService
    {
        Task<Models.User> GetUserById(string userId);
        Task<Models.User> GetUserByEmail(string userEmail);
        Task<Models.User> UserLogin(UserLoginDto userLoginDto);
    }
}
