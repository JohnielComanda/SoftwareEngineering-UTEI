using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository.EnhanceUnitTest
{
    public class EfficiencyTestRepository : IEfficiencyTestRepository
    {
        private readonly IMongoCollection<EfficiencyTest> _efficiencyTest;
        public EfficiencyTestRepository(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _efficiencyTest = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<EfficiencyTest>(options.Value.EfficiencyTestsCollectionName);
        }

        public async Task<string> CreateTest(EfficiencyTest testEfficiency)
        {
            await _efficiencyTest.InsertOneAsync(testEfficiency);
            return testEfficiency.Id!;
        }

        public Task<bool> DeleteAllTests()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTestById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EfficiencyTest>> GetAllSavedTest()
        {
            var filter = new BsonDocument();
            var cursor = await _efficiencyTest.FindAsync(filter);

            return await cursor.ToListAsync();
        }

        public async Task<EfficiencyTest> GetSavedTest(string id)
        {
            return await _efficiencyTest.Find(test => test.Id == id).FirstOrDefaultAsync();
        }
    }
}
