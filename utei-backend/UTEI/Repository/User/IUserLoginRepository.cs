using UTEI.Dtos;

namespace UTEI.Repository.User
{
    public interface IUserLoginRepository
    {
        Task<Models.User> GetUserById(string userId);
        Task<Models.User> GetUserByEmail(string userEmail);
        Task<Models.User> UserLogin(UserLoginDto userLoginDto);
    }
}
