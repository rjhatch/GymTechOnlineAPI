using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GymTechOnlineAPI.Models
{
    public class FormatElement : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Position")]
        [JsonPropertyName("Position")]
        public int Position { get; set; }

        [BsonElement("Hidden")]
        [JsonPropertyName("Hidden")]
        public bool Hidden { get; set; }

        [BsonElement("Required")]
        [JsonPropertyName("Required")]
        public bool Required { get; set; }

        [BsonElement("Label")]
        [JsonPropertyName("Label")]
        public string Label { get; set; } = null!;

        [BsonExtraElements]
        public IDictionary<string, object>? CatchAll { get; set; }
    }
}
