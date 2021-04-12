using System;

namespace NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson.Models
{
    public class AddPersonCommandModel : BaseCommand
    {
        public string CreatedBy { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public AddPersonCommandModel(string executionUser, string createdBy, string name, string address, string phone) 
            : base(executionUser)
        {
            CreatedBy = createdBy;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}