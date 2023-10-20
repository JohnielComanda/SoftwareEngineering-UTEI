using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Repository.User
{
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly IMongoCollection<Models.User> _user;
        public UserLoginRepository(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _user = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Models.User>(options.Value.UsersCollectionName);
        }

        public async Task<Models.User> GetUserByEmail(string userEmail)
        {
            return await _user.Find(email => email.Email == userEmail).FirstOrDefaultAsync();
        }

        public async Task<Models.User> GetUserById(string userId)
        {
            return await _user.Find(email => email.Id == userId).FirstOrDefaultAsync();
        }

        public async Task<Models.User?> UserLogin(UserLoginDto userLoginDto)
        {
            var filter = Builders<Models.User>.Filter.Where(u => u.Email == userLoginDto.Email && u.Password == userLoginDto.Password);
            return await _user.Find(filter).FirstOrDefaultAsync();
        }
    }
}
