using System.Collections.Generic;
using NSubstitute;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.LibRoot.MetricServiceTests;

public static class TestHelper
{
  public static MetricService GetMetricService(
    ILoggerAdapter<MetricService>? logger = null,
    IDateTimeAbstraction? dateTime = null,
    IEnumerable<IMetricOutput>? outputs = null,
    RnMetricsConfig? config = null)
  {
    return new MetricService(
      logger ?? Substitute.For<ILoggerAdapter<MetricService>>(),
      dateTime ?? new DateTimeAbstraction(),
      outputs ?? new List<IMetricOutput>(),
      config ?? RnMetricsConfigBuilder.Default);
  }
}
