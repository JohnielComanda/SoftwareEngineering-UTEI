using UTEI.Dtos;
using UTEI.Models;
using UTEI.Repository.User;

namespace UTEI.Service.User
{
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUserRegisterRepository _repository;
        public UserRegisterService(IUserRegisterRepository repository)
        {
            _repository = repository;
        }

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
