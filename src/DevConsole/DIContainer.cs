using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Rn.NetCore.Metrics.Extensions;

namespace DevConsole;

public static class DIContainer
{
  public static IServiceProvider Get()
  {
    var services = new ServiceCollection();

    var config = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .Build();

    services
      .AddSingleton<IConfiguration>(config)
      .AddRnMetricsBase(config)

      .AddLogging(loggingBuilder =>
      {
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(LogLevel.Trace);
        loggingBuilder.AddNLog(config);
      });

    return services.BuildServiceProvider();
  }
}
