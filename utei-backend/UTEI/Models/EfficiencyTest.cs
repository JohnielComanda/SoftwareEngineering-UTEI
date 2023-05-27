using MongoDB.Bson.Serialization.Attributes;

namespace UTEI.Models
{
    public class EfficiencyTest
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? UnitTest { get; set; }
        public string? ProgrammingLanguage { get; set; }
        public DateTime Date { get; set; }
        public string? ResultSummary { get; set; }
        public int EfficiencyScore { get; set; }
        public string? TestSuggestions { get; set; }
        public string? EnhancedVersion { get; set; }

    }
}
