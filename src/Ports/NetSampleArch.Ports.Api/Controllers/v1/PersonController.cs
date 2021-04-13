using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NetSampleArch.Ports.Api.Controllers.v1;
using NetSampleArch.Infra.CrossCutting.Bus.Interfaces;
using NetSampleArch.Infra.CrossCutting.Bus.Handlers.Events.DomainNotifications.Interfaces;
using Serilog;
using NetSampleArch.Ports.Api.Response;
using System.Net;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson.Models;
using System.Threading;
using NetSampleArch.Ports.Api.Payloads;
using System.Threading.Tasks;
using NetSampleArch.Infra.CrossCutting.Messages.Internal.Commands.AddPerson;

namespace NetSampleArch.Ports.Api.Controllers
{
    [ApiController]
    [ApiVersion("1", Deprecated = false)]
    [Route("api/v{version:apiVersion}/persons/")]
    [Produces("application/json")]
    public class PersonController : V1BaseController
    {
        private readonly LinkGenerator _linkGenerator;

        public PersonController(ILogger logger, IBus bus, IRaisedDomainNotifications raisedDomainNotifications)
            : base(logger, bus, raisedDomainNotifications)
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<bool>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(AddPersonPayload payload, CancellationToken cancellationToken)
        {
            var resultCommand = await Bus.SendCommandAsync<AddPersonCommand, bool>(command: new AddPersonCommand(
                input: new AddPersonCommandModel(
                    executionUser: payload.ExecutionUser,
                    createdBy: payload.ExecutionUser,
                    name: payload.Name,
                    address: payload.Address,
                    phone: payload.Phone
                )),
                cancellationToken: cancellationToken
            ).ConfigureAwait(false);

            return Ok(CreateResponseObject(resultCommand));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok();
        }
    }
}
