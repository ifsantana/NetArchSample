using NetSampleArch.Ports.Api.Response.Enums;
using NetSampleArch.Ports.Api.Response.Models;
using System.Collections.Generic;

namespace NetSampleArch.Ports.Api.Response
{
    public class BaseResponse<T>
    {
        public ExecutionStatus ExecutionResponseStatus { get; set; }
        public string ExecutionResponseStatusDescription => ExecutionResponseStatus.ToString();
        public T Data { get; set; }
        public List<ResponseMessage> ResponseMessageCollection { get; set; }

        public BaseResponse()
        {
            ResponseMessageCollection = new List<ResponseMessage>();
        }
    }
}
