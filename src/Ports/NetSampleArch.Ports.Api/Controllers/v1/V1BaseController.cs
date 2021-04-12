using Microsoft.AspNetCore.Mvc;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Enums;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Ports.Api.Response;
using NetSampleArch.Ports.Api.Response.Enums;
using Serilog;

namespace NetSampleArch.Ports.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class V1BaseController : ControllerBase
    {
		protected ILogger Logger { get; }
		protected IBus Bus { get; }
		protected IRaisedDomainNotifications RaisedDomainNotifications { get; }

		protected V1BaseController(ILogger logger, IBus bus, IRaisedDomainNotifications raisedDomainNotifications)
		{
			Logger = logger;
			Bus = bus;
			RaisedDomainNotifications = raisedDomainNotifications;
		}

		protected BaseResponse<TData> CreateResponseObject<TData>(TData data)
		{
			var response = new BaseResponse<TData>
			{
				Data = data
			};

			if (RaisedDomainNotifications.IsSuccess)
			{
				response.ExecutionResponseStatus = ExecutionStatus.Success;
			}
			else
			{
				if (RaisedDomainNotifications.ValidationStatus == ValidationStatus.Partial)
					response.ExecutionResponseStatus = ExecutionStatus.PartialSuccess;
				else
					response.ExecutionResponseStatus = ExecutionStatus.Error;
			}

			foreach (var domainNotification in RaisedDomainNotifications.AllDomainNotificationEventCollection)
			{
				response.ResponseMessageCollection.Add(new Response.Models.ResponseMessage
				{
					Code = domainNotification.Code,
					MessageType = domainNotification.NotificationTypeName,
					Message = domainNotification.Code
				});
			}

			return response;
		}
	}
}
