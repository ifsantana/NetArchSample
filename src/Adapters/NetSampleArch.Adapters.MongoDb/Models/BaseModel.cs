using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetSampleArch.Adapters.MongoDb.Models
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public TimeSpan RowVersion { get; set; }
    }
}