namespace NetSampleArch.Application.UseCases.ReplicatePersonToQuerieDb.Models
{
    public class AddedPersonUseCaseModel : BaseUseCaseModel
    {
        public string CreatedBy { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public AddedPersonUseCaseModel(string executionUser, string createdBy, string name, string address, string phone)
            : base(executionUser)
        {
            CreatedBy = createdBy;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}
