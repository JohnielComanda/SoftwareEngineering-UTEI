using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository.GenerateUnitTest
{
    public class GenerateTestRepository : IGenerateTestRepository
    {
        private readonly IMongoCollection<GenerateTest> _generateTest;
        public GenerateTestRepository(IOptions<DatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _generateTest = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<GenerateTest>(options.Value.GenerateTestsCollectionName);
        }

        public async Task<string> CreateTest(GenerateTest generateTest)
        {
            await _generateTest.InsertOneAsync(generateTest);
            return generateTest.Id!;
        }

        public Task<bool> DeleteAllTests()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTestById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenerateTest>> GetAllSavedTest()
        {
            throw new NotImplementedException();
        }

        public async Task<GenerateTest> GetSavedTest(string id)
        {
            return await _generateTest.Find(test => test.Id == id).FirstOrDefaultAsync();
        }
    }
}
