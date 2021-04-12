namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.ReplicatePersonCreated.Models
{
    public class PersonCreatedEntry : BaseCommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        
        public PersonCreatedEntry(string executionUser, string createdBy, string name, string address, string phone) 
            : base(executionUser)
        {
            CreatedBy = createdBy;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}