using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Assessment.Domain;

public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
}