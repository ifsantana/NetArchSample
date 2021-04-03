using Microsoft.AspNetCore.Builder;

namespace NetSampleArch.Ports.Api.Middlewares
{
    public static class UseExceptionLogHandlerExtension
    {
        public static IApplicationBuilder UseExceptionLogHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware<UseExceptionLogHandler>();
    }
}