using System;

namespace NetSampleArch.Application.UseCases.AddPerson.Models
{
    public class AddPersonUseCaseModel : BaseUseCaseModel
    {
        public string CreatedBy { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public AddPersonUseCaseModel(string executionUser, string createdBy, string name, string address, string phone)
            : base(executionUser)
        {
            CreatedBy = createdBy;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}
