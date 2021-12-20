using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GymTechOnlineAPI.Models
{
    public class FormatDocument : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Document Name")]
        [JsonPropertyName("Document Name")]
        public string DocumentName { get; set; } = null!;

        [BsonElement]
        public FormatElement[]? Elements { get; set; }
    }
}
