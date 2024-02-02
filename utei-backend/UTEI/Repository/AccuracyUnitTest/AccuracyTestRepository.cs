using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository.AccuracyUnitTest
{
    public class AccuracyTestRepository : IAccuracyTestRepository
    {
        private readonly IMongoCollection<AccuracyTestModel> _accuracyTest;
        public AccuracyTestRepository(IOptions<DatabaseSettings> options)
        {
            var connectionUri = "mongodb+srv://JohnielComanda:FYsVjt5pqg3bJCA2@cluster0.hg9di7y.mongodb.net/?retryWrites=true&w=majority";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var mongoClient = new MongoClient(settings);
            _accuracyTest = mongoClient.GetDatabase("UTEI")
                .GetCollection<AccuracyTestModel>("AccuracyTest");
        }

        public async Task<string> CreateTest(AccuracyTestModel testAccuracy)
        {
            await _accuracyTest.InsertOneAsync(testAccuracy);
            return testAccuracy.Id!;
        }

        public async Task<IEnumerable<AccuracyTestModel>> GetAllSavedTest()
        {
            var filter = new BsonDocument();
            var cursor = await _accuracyTest.FindAsync(filter);

            return await cursor.ToListAsync();
        }

        public async Task<AccuracyTestModel> GetSavedTest(string id)
        {
            return await _accuracyTest.Find(test => test.Id == id).FirstOrDefaultAsync();
        }
    }
}
