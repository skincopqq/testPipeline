using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace abpTemp.Administration
{
    public class LogCookiesAndRefererMiddleware
    {
        private readonly RequestDelegate _next;

        public LogCookiesAndRefererMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("auth middleware");
            var RemoteIpAddress = context.Connection.RemoteIpAddress;
            var RemotePort = context.Connection.RemotePort;
            var a = context.Request;

            Console.WriteLine(RemoteIpAddress);
            Console.WriteLine(RemotePort);

            await _next(context);
        }
    }
}
