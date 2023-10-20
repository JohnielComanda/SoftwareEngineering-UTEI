using UTEI.Models;

namespace UTEI.Repository.User
{
    public interface IUserRegisterRepository
    {
        Task<string> CreateUser(Models.User user);
    }
}
