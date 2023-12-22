using UTEI.Dtos;

namespace UTEI.Service.User
{
    public interface IUserLoginService
    {
        /// <summary>
        /// This is for getting a user information given by it's id
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>Returns user information</returns>
        Task<Models.User> GetUserById(string userId);

        /// <summary>
        /// This is for getting a user information given by it's email
        /// </summary>
        /// <param name="userEmail">Email of the user</param>
        /// <returns>Returns user information</returns>
        Task<Models.User> GetUserByEmail(string userEmail);

        /// <summary>
        /// This is for authenticating the user credentials inputted if it exists in the database
        /// </summary>
        /// <param name="userLoginDto">User credentials</param>
        /// <returns>Returns true or false</returns>
        Task<Models.User> UserLogin(UserLoginDto userLoginDto);
    }
}
