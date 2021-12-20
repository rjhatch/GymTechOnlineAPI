using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GymTechOnlineAPI.Models
{
    public class Person : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("First Name")]
        [JsonPropertyName("First Name")]
        public string FirstName { get; set; } = null!;

        [BsonElement("Last Name")]
        [JsonPropertyName("Last Name")]
        public string LastName { get; set; } = null!;

        [BsonElement("Membership Type")]
        [JsonPropertyName("Membership Type")]
        public string MembershipType { get; set; } = null!;

        [BsonExtraElements]
        public IDictionary<string, object>? CatchAll { get; set; }
    }
}
