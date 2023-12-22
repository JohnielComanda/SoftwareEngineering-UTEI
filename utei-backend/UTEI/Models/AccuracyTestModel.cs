using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace UTEI.Models
{
    /// <summary>
    /// Models for accuracy test
    /// </summary>
    public class AccuracyTestModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? UnitTest { get; set; }
        public string? BaseMethod { get; set; }
        public string? ProgrammingLanguage { get; set; }
        public DateTime Date { get; set; }
        public string? ResultSummary { get; set; }
        public string? TestResult { get; set; }
        public string? TestSuggestions { get; set; }
        public string? EnhancedVersion { get; set; }
    }
}
