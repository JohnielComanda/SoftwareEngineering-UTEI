using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository.User
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        /// <summary>
        /// This is for calling an instance of IMongoCollection and pass the User Model
        /// </summary>
        private readonly IMongoCollection<Models.User> _user;

        /// <summary>
        /// This is for setting up / connecting the GenerateTest Repository to the mongoClient and passing all necessary parameters/options
        /// </summary>
        /// <param name="options"></param>
        public UserRegisterRepository(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);

            var userCollection = database.GetCollection<Models.User>(options.Value.UsersCollectionName);
            var keys = Builders<Models.User>.IndexKeys.Ascending(u => u.Email);
            var indexOptions = new CreateIndexOptions { Unique = true };
            var model = new CreateIndexModel<Models.User>(keys, indexOptions);
            userCollection.Indexes.CreateOne(model);

            _user = userCollection;
        }

        /// <summary>
        /// This is for the creation of user
        /// </summary>
        /// <param name="user">User model that will be stored in the database</param>
        /// <returns>Returns the id of the newly created user</returns>
        public async Task<string> CreateUser(Models.User user)
       {
            await _user.InsertOneAsync(user);
            return user.Id!;
        }
    }
}
