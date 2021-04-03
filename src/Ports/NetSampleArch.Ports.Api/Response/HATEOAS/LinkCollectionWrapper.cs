using System.Collections.Generic;

namespace NetSampleArch.Ports.Api.Response.HATEOAS
{
    public class LinkCollectionWrapper<T> : LinkResourceBase
    {
        public List<T> Value { get; set; } = new List<T>();
        public LinkCollectionWrapper() {}
        public LinkCollectionWrapper(List<T> value)
        {
            Value = value;
        }
    }
}