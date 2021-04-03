using System.Collections.Generic;

namespace NetSampleArch.Ports.Api.Response.HATEOAS
{
    public class LinkResourceBase
    {
        public LinkResourceBase() {}
        public List<Link> Links { get; set; } = new List<Link>();
    }
}