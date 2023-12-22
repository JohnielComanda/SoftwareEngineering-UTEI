using UTEI.Dtos;
using UTEI.Models;
using UTEI.Repository.User;

namespace UTEI.Service.User
{
    public class UserRegisterService : IUserRegisterService
    {
        /// <summary>
        /// This is for calling an instance of the IUserRegisterRepository
        /// </summary>
        private readonly IUserRegisterRepository _repository;
        public UserRegisterService(IUserRegisterRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// This is for registering a user
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns>Returns the id of the newly created user</returns>
        public async Task<string> CreateUser(UserCreationDto user)
        {
            var newUser = new Models.User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            return await _repository.CreateUser(newUser);
        }
    }
}
