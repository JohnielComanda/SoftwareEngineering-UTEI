using UTEI.Dtos;
using UTEI.Repository.User;

namespace UTEI.Service.User
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _repository;
        public UserLoginService(IUserLoginRepository repository)
        {
            _repository = repository;   
        }
        public async Task<Models.User> GetUserByEmail(string userEmail)
        {
            return await _repository.GetUserByEmail(userEmail);
        }

        public async Task<Models.User> GetUserById(string userId)
        {
            return await _repository.GetUserById(userId);
        }

        public async Task<Models.User> UserLogin(UserLoginDto userLoginDto)
        {
            return await _repository.UserLogin(userLoginDto);
        }
    }
}
