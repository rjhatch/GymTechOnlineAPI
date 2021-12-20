using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GymTechOnlineAPI.Models
{
    public class Payment : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Description")]
        [JsonPropertyName("Description")]
        public string Description { get; set; } = null!;

        [BsonElement("Amount")]
        [JsonPropertyName("Amount")]
        public string Amount { get; set; } = null!;

        [BsonElement("Status")]
        [JsonPropertyName("Status")]
        public string Status { get; set; } = null!;

        [BsonExtraElements]
        public IDictionary<string, object>? CatchAll { get; set; }
    }
}
