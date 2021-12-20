using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GymTechOnlineAPI.Models
{
    public class Session : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Title")]
        [JsonPropertyName("Title")]
        public string Title { get; set; } = null!;

        [BsonElement("Start Time")]
        [JsonPropertyName("Start Time")]
        public string StartTime { get; set; } = null!;

        [BsonElement("Duration")]
        [JsonPropertyName("Duration")]
        public string Duration { get; set; } = null!;

        [BsonExtraElements]
        public IDictionary<string, object>? CatchAll { get; set; }
    }
}
