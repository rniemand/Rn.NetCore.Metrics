using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Rn.NetCore.Metrics;
using Rn.NetCore.Metrics.Extensions;

namespace DevConsole;

internal class Program
{
  private static IServiceProvider _services;

  static void Main(string[] args)
  {
    ConfigureDI();

    var metricsService = _services.GetRequiredService<IMetricService>();

    Console.WriteLine();
    Console.WriteLine();
  }

  private static void ConfigureDI()
  {
    var services = new ServiceCollection();

    var config = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .Build();

    services
      .AddSingleton<IConfiguration>(config)
      .AddRnMetricsBase()

      .AddLogging(loggingBuilder =>
      {
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(LogLevel.Trace);
        loggingBuilder.AddNLog(config);
      });

    _services = services.BuildServiceProvider();
  }
}
