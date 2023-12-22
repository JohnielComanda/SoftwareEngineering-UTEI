using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Dtos;
using UTEI.Models;

namespace UTEI.Repository.User
{
    public class UserLoginRepository : IUserLoginRepository
    {
        /// <summary>
        /// This is for calling an instance of IMongoCollection and pass the User Model
        /// </summary>
        private readonly IMongoCollection<Models.User> _user;

        /// <summary>
        /// This is for setting up / connecting the GenerateTest Repository to the mongoClient and passing all necessary parameters/options
        /// </summary>
        /// <param name="options"></param>
        public UserLoginRepository(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _user = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Models.User>(options.Value.UsersCollectionName);
        }

        /// <summary>
        /// This is for getting the user's info given by an email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns>Returns user information</returns>
        public async Task<Models.User> GetUserByEmail(string userEmail)
        {
            return await _user.Find(email => email.Email == userEmail).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This is for getting the user's info given by an id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns user information</returns>
        public async Task<Models.User> GetUserById(string userId)
        {
            return await _user.Find(email => email.Id == userId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This is for checking a user's inputted credentials if it has a match in the database
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns>Returns user information if a user is found</returns>
        public async Task<Models.User?> UserLogin(UserLoginDto userLoginDto)
        {
            var filter = Builders<Models.User>.Filter.Where(u => u.Email == userLoginDto.Email && u.Password == userLoginDto.Password);
            return await _user.Find(filter).FirstOrDefaultAsync();
        }
    }
}
