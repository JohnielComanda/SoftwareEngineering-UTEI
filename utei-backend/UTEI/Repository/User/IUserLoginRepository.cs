using UTEI.Dtos;

namespace UTEI.Repository.User
{

    public interface IUserLoginRepository
    {
        /// <summary>
        /// This is for getting the user's info given by an id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns user information</returns>
        Task<Models.User> GetUserById(string userId);

        /// <summary>
        /// This is for getting the user's info given by an email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>Returns user information</returns>
        Task<Models.User> GetUserByEmail(string userEmail);

        /// <summary>
        /// This is for checking a user's inputted credentials if it has a match in the database
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns>Returns user information if a user is found</returns>
        Task<Models.User> UserLogin(UserLoginDto userLoginDto);
    }
}
