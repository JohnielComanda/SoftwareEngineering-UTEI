using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository.EnhanceUnitTest
{
    public class EfficiencyTestRepository : IEfficiencyTestRepository
    {
        /// <summary>
        /// This is for calling an instance of IMongoCollection and pass the EfficiencyTest Model
        /// </summary>
        private readonly IMongoCollection<EfficiencyTest> _efficiencyTest;

        /// <summary>
        /// This is for setting up / connecting the Efficiency Test Repository to the mongoClient and passing all necessary parameters/options
        /// </summary>
        /// <param name="options"></param>
        public EfficiencyTestRepository(IOptions<DatabaseSettings> options)
        {
            var connectionUri = "mongodb+srv://JohnielComanda:FYsVjt5pqg3bJCA2@cluster0.hg9di7y.mongodb.net/?retryWrites=true&w=majority";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var mongoClient = new MongoClient(settings);
            _efficiencyTest = mongoClient.GetDatabase("UTEI")
                .GetCollection<EfficiencyTest>("EfficiencyTest");
        }

        /// <summary>
        /// This is for the creation of efficiency test
        /// </summary>
        /// <param name="testEfficiency"></param>
        /// <returns>Returns the id of efficiency test result</returns>
        public async Task<string> CreateTest(EfficiencyTest testEfficiency)
        {
            await _efficiencyTest.InsertOneAsync(testEfficiency);
            return testEfficiency.Id!;
        }

        /// <summary>
        /// This is for getting all efficiency test that is in database
        /// </summary>
        /// <returns>Returns a result of all the previously done efficiency test</returns>
        public async Task<IEnumerable<EfficiencyTest>> GetAllSavedTest()
        {
            var filter = new BsonDocument();
            var cursor = await _efficiencyTest.FindAsync(filter);

            return await cursor.ToListAsync();
        }

        /// <summary>
        /// This is for getting an efficiency test given the ID of the test
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a result of previously done efficiency test</returns>
        public async Task<EfficiencyTest> GetSavedTest(string id)
        {
            return await _efficiencyTest.Find(test => test.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteAllTests()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteTestById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
