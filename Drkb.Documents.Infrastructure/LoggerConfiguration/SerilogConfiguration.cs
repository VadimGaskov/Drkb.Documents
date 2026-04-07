using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace Drkb.Documents.Infrastructure.LoggerConfiguration;

public static class SerilogConfiguration
{
    public static Logger GetSerilogConfiguration(ConfigurationManager configuration)
    {
        return new Serilog.LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }
}