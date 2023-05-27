using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository
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

        public Task<bool> DeleteTestById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EfficiencyTest>> GetAllSavedTest()
        {
            throw new NotImplementedException();
        }

        public Task<EfficiencyTest> GetSavedTest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
