﻿using Microsoft.Extensions.Options;
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
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _accuracyTest = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<AccuracyTestModel>(options.Value.AccuracyTestsCollectionName);
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
