namespace NetSampleArch.Adapters.MongoDb.Models
{
    public class Person : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}