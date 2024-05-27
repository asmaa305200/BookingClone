using BookingClone.Serilog;
using BookingClone.YARP.ProxyConfigurations;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;
using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
    options.ConfigureHttpsDefaults(s => s.AllowAnyClientCertificate());
    options.ConfigureEndpointDefaults(o => o.Protocols = HttpProtocols.Http1AndHttp2AndHttp3);
});

builder.Host.UseSerilog(Serilogger.Configure);

builder.Services.AddStackExchangeRedisCache(redisOptions
    => redisOptions.Configuration = builder.Configuration.GetConnectionString("RedisConnection"));

var conf = new BookingProxyConfig(builder.Configuration).GetConfig();

builder.Services//.AddSingleton<IProxyConfigProvider>(new BookingProxyConfig())
    .AddReverseProxy()
    .LoadFromMemory(conf.Routes, conf.Clusters);

var app = builder.Build();

app.MapGet("/", () => "This is the YARP Endpoint");

app.MapGet("/UpdateProxy", (HttpContext context, IProxyConfigProvider provider) =>
{
    var x = provider.GetConfig();
    context.RequestServices.GetRequiredService<InMemoryConfigProvider>().Update(x.Routes, x.Clusters);
});

app.MapReverseProxy();

app.Run();
