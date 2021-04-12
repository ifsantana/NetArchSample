namespace NetSampleArch.Adapters.EFCore.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
     public class PersonDataModel : BaseModel
    {   
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}