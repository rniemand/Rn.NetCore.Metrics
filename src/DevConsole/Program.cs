using System;
using System.Threading;
using Rn.NetCore.Metrics.Builders;

namespace DevConsole;

internal class Program
{
  static void Main(string[] args)
  {
    var metricBuilder = new CronMetricBuilderNew()
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

    var metric = metricBuilder.Build();

    Console.WriteLine();
    Console.WriteLine();
  }
}
