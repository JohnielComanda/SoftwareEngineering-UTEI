using UTEI.Dtos;

namespace UTEI.Service.User
{
    public interface IUserRegisterService
    {
        Task<string> CreateUser(UserCreationDto user);
    }
}
