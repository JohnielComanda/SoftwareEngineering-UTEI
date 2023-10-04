using MongoDB.Bson.Serialization.Attributes;

namespace UTEI.Models
{
    public class GenerateTest
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string ?BaseMethod { get; set; }
        public string? ProgrammingLanguage { get; set; }
        public DateTime? Date { get; set; }
        public string? UnitTest { get; set; }
    }
}
