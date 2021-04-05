namespace NetSampleArch.Adapters.SQLServer.Models
{
     public abstract class Person : BaseModel
    {   
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}