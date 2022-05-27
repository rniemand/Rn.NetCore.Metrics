using System;
using Microsoft.Extensions.DependencyInjection;
using Rn.NetCore.Metrics;

namespace DevConsole;

internal class Program
{
  private static readonly IServiceProvider Services = DIContainer.Get();

  static void Main(string[] args)
  {
    var metricsService = Services.GetRequiredService<IMetricService>();



    Console.WriteLine();
    Console.WriteLine();
  }
}
