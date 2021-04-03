using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace NetSampleArch.Ports.Api.Middlewares
{
   public class UseExceptionLogHandler
    {
        private readonly RequestDelegate _nextRequest;
        private readonly ILogger _logger;

        public UseExceptionLogHandler(RequestDelegate nextRequest, ILogger logger)
        {
            _nextRequest = nextRequest ?? throw new ArgumentException(nameof(nextRequest));
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _nextRequest.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Caught ans exception at path: {context.Request.Path}");
                throw;
            }
        }
    }
}