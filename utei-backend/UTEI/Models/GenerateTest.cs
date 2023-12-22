using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace UTEI.Models
{
    /// <summary>
    /// Model for generate test
    /// </summary>
    public class GenerateTest
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string ?BaseMethod { get; set; }
        public string? ProgrammingLanguage { get; set; }
        public DateTime? Date { get; set; }
        public string? UnitTest { get; set; }
    }
}
