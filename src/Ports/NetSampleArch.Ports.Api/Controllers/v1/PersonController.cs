﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace NetSampleArch.Ports.Api.Controllers
{
    [ApiController]
    [ApiVersion("1", Deprecated = false)]
    [Route("api/{version:apiversion}/persons/")]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
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