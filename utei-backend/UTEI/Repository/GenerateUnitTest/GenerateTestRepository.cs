using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using UTEI.DatabaseSetting;
using UTEI.Models;

namespace UTEI.Repository.GenerateUnitTest
{
    public class GenerateTestRepository : IGenerateTestRepository
    {
        /// <summary>
        /// This is for calling an instance of IMongoCollection and pass the GenerateTest Model
        /// </summary>
        private readonly IMongoCollection<GenerateTest> _generateTest;

        /// <summary>
        /// This is for setting up / connecting the GenerateTest Repository to the mongoClient and passing all necessary parameters/options
        /// </summary>
        /// <param name="options"></param>
        public GenerateTestRepository(IOptions<DatabaseSettings> options)
        {
            var connectionUri = Environment.GetEnvironmentVariable("MongoDBConnection");
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var mongoClient = new MongoClient(settings);
            _generateTest = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("DatabaseName"))
                .GetCollection<GenerateTest>("GenerateTest");
        }

        /// <summary>
        /// This is for creation of generate test
        /// </summary>
        /// <param name="generateTest"></param>
        /// <returns>Returns the id of generate test result</returns>
        public async Task<string> CreateTest(GenerateTest generateTest)
        {
            await _generateTest.InsertOneAsync(generateTest);
            return generateTest.Id!;
        }

        /// <summary>
        /// This is for getting all generate test result from the database
        /// </summary>
        /// <returns>Returns all previously done generate test result</returns>
        public async Task<IEnumerable<GenerateTest>> GetAllSavedTest()
        {
            var filter = new BsonDocument();
            var cursor = await _generateTest.FindAsync(filter);

            return await cursor.ToListAsync();
        }

        /// <summary>
        /// This is for getting a generate test result given an id of the test
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the previously done generate test result</returns>
        public async Task<GenerateTest> GetSavedTest(string id)
        {
            return await _generateTest.Find(test => test.Id == id).FirstOrDefaultAsync();
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
