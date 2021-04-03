using System;
using MassTransit;
using NetSampleArch.Domain.Entities.Interfaces;

namespace NetSampleArch.Domain.Entities
{
    public abstract class BaseEntity
        : IEntity
    {
        private NewId _newId = new NewId();

        public Guid Id
        {
            get => Guid.Parse(_newId.ToString("D"));
            protected set => _newId = new NewId(value.ToString());
        }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string UpdatedBy { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public TimeSpan RowVersion { get; protected set; }

        protected void SetExistingId(Guid id)
        {
            Id = id;
        }
        protected void GenerateNewId()
        {
            Id = NewId.NextGuid();
        }

        protected void SetCreationInfo(string createdBy, DateTime createdAt)
        {
            CreatedAt = createdAt;
            CreatedBy = createdBy;
        }
        protected void SetUpdateInfo(string updatedBy, DateTime? updatedAt)
        {
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
        }

        protected void SetExistingRowVersion(TimeSpan rowVersion)
        {
            RowVersion = rowVersion;
        }
        protected void GenerateNewRowVersion()
        {
            RowVersion = TimeSpan.FromTicks(DateTime.UtcNow.Ticks); 
        }
    }
}