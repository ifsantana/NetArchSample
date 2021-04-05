using System;

namespace NetSampleArch.Adapters.MongoDb.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public TimeSpan RowVersion { get; set; }
    }
}