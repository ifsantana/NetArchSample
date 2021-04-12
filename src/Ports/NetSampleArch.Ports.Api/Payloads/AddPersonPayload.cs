using NetSampleArch.Ports.Api.Payloads.Base;

namespace NetSampleArch.Ports.Api.Payloads
{
    public class AddPersonPayload : PayloadBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
