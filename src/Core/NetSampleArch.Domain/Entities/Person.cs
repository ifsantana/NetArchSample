using NetSampleArch.Domain.Entities;
using NetSampleArch.Domain.Entities.Interfaces;

namespace NetSampleArch.Domain
{
    public abstract class Person : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
