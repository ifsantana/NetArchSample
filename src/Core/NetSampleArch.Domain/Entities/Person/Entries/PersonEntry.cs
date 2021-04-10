using NetSampleArch.Domain.Entities.Interfaces;
using System;

namespace NetSampleArch.Domain.Entities.Person.Entries
{
    public class PersonEntry : BaseEntity, IAggregateRoot
    {
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string Phone { get; protected set; }

        public PersonEntry(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        protected void SetPersonInfo(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        protected virtual void RegisterNewPersonEntry(string name, string address, string phone, string createdBy)
        {
            GenerateNewId();
            GenerateNewRowVersion();
            SetCreationInfo(createdBy, DateTime.UtcNow);
            SetPersonInfo(name, address, phone);
        }
    }
}
