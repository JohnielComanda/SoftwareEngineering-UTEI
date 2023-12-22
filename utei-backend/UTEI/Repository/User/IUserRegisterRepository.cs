using UTEI.Models;

namespace UTEI.Repository.User
{
    public interface IUserRegisterRepository
    {
        /// <summary>
        /// This is for the creation of user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the id of the newly created user</returns>
        Task<string> CreateUser(Models.User user);
    }
}
