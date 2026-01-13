using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskManager_API.Models
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Title")]
        public string TaskName { get; set; } = null!;
        [BsonElement("DateStart")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime TaskDateStart { get; set; }
        [BsonElement("DateEnd")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime TaskDateEnd { get; set; }
    }
}
