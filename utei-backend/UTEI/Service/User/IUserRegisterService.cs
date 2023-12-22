using UTEI.Dtos;

namespace UTEI.Service.User
{
    public interface IUserRegisterService
    {
        /// <summary>
        /// This is for registering a user
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns>Returns the id of the newly created user</returns>
        Task<string> CreateUser(UserCreationDto user);
    }
}
