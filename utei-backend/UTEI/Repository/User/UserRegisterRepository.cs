using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository.User
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private readonly IMongoCollection<Models.User> _user;

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
        public async Task<string> CreateUser(Models.User user)
       {
            await _user.InsertOneAsync(user);
            return user.Id!;
        }
    }
}
