using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace UTEI.Models
{
    /// <summary>
    /// Model used for user sign in / sign up
    /// </summary>
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
