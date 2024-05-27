using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Elasticsearch;

namespace BookingClone.Serilog;

public static class Serilogger
{
    /// <summary>
    /// The main configuration for Serilog
    /// </summary>
    public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
        (context, configuration) =>
        {
            SelfLog.Enable(msg => Console.WriteLine(msg));
            string? elasticUrl = context.Configuration.GetConnectionString("Elasticsearch");

            var conf = configuration
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Console()
                .WriteTo.Debug();

            if (context.HostingEnvironment.IsEnvironment("DockerDevelopment"))
            {
                conf.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUrl!))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = $"applogs-{context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    NumberOfShards = 2,
                    NumberOfReplicas = 1,
                    FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog
                });
            }

            conf.ReadFrom.Configuration(context.Configuration);
        };
}
