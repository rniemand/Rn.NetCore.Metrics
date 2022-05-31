using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Rn.NetCore.Metrics;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Extensions;

namespace DevConsole;

internal class Program
{
  static void Main(string[] args)
  {
    var metricBuilder = new CronMetricBuilder()
      .WithCustomTag1("op")
      .WithCustomLong1(8)
      .WithCustomInt4(9)
      .MarkFailed();

    using (metricBuilder.WithTiming())
    {
      using (metricBuilder.WithCustomTiming1())
      {
        Thread.Sleep(125);
      }
    }
    
    DIContainer.Get()
      .GetRequiredService<IMetricService>()
      .Submit(metricBuilder);

    Console.WriteLine();
    Console.WriteLine();
  }
}
