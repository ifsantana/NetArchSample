using NetSampleArch.Domain.Entities.Interfaces;
using NetSampleArch.Domain.Entities.Person.Entries;
using System;

namespace NetSampleArch.Domain.Entities.Person
{
    public class Person : BaseEntity, IAggregateRoot
    {
        public string Name { get; protected set; }
        public string Address { get; protected set; }
        public string Phone { get; protected set; }

        protected void SetPersonInfo(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public void UpdateFromAssetEntry(PersonEntry assetEntry)
        {
            if (Id == Guid.Empty)
            {
                GenerateNewId();
                SetCreationInfo(assetEntry.CreatedBy, assetEntry.CreatedAt);
            }
            else
            {
                SetUpdateInfo(assetEntry.UpdatedBy ?? assetEntry.CreatedBy, DateTime.UtcNow);
            }

            GenerateNewId();
            GenerateNewRowVersion();
            SetCreationInfo(assetEntry.CreatedBy, DateTime.UtcNow);
            SetPersonInfo(assetEntry.Name, assetEntry.Address, assetEntry.Phone);
        }
    }
}
