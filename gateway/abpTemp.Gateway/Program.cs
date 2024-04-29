using abpTemp.Gateway;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.UseMiddleware<LogCookiesAndRefererMiddleware>();
app.MapReverseProxy();
app.Run();
