namespace NetSampleArch.Adapters.MongoDb.Models
{
    public class PersonDataModel : BaseModel
    {
        public string CommandModelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}