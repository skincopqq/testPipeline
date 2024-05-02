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
            var flag = context.Request.Headers.TryGetValue("Authorization", out var auth);
            if (flag)
            {
                dasd
                Console.WriteLine(auth);
            }
            else
            {
                Console.WriteLine("NO AUTH");
            }

            await _next(context);
        }
    }
}
