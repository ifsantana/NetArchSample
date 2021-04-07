using System;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.Models
{
    public class PersonCreatedEntry : BaseCommand
    {
        public Guid Id {get;}
        public string CreatedBy { get; }
        public DateTime CreatedAt { get; }
        public string UpdatedBy { get; }
        public DateTime? UpdatedAt { get; }
        public TimeSpan RowVersion { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public PersonCreatedEntry(string executionUser, string createdBy, DateTime createdAt,
        string updatedBy, DateTime? updatedAt, TimeSpan rowVersion, string name, string address, string phone) 
            : base(executionUser)
        {
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            UpdatedBy = updatedBy;
            UpdatedAt = updatedAt;
            RowVersion = rowVersion;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}