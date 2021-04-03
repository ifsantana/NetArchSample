using System;

namespace NetSampleArch.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; }
        string CreatedBy { get; }
        string UpdatedBy { get; }
        TimeSpan RowVersion { get; }
    }
}