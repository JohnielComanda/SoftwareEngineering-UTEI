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

        /// <summary>
        /// This is for getting a user information given by it's email
        /// </summary>
        /// <param name="userEmail">Email of the user</param>
        /// <returns>Returns user information</returns>
        public async Task<Models.User> GetUserByEmail(string userEmail)
        {
            return await _repository.GetUserByEmail(userEmail);
        }

        /// <summary>
        /// This is for getting a user information given by it's id
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>Returns user information</returns>
        public async Task<Models.User> GetUserById(string userId)
        {
            return await _repository.GetUserById(userId);
        }

        /// <summary>
        /// This is for authenticating the user credentials inputted if it exists in the database
        /// </summary>
        /// <param name="userLoginDto">User credentials</param>
        /// <returns>Returns true or false</returns>
        public async Task<Models.User> UserLogin(UserLoginDto userLoginDto)
        {
            return await _repository.UserLogin(userLoginDto);
        }
    }
}
