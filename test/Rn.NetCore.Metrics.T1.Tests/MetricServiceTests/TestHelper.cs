using System;
using System.Collections.Generic;
using NSubstitute;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceTests;

public static class TestHelper
{
  public static IServiceProvider GetServiceProvider(
    ILoggerAdapter<MetricService> logger = null,
    IDateTimeAbstraction dateTime = null,
    IMetricServiceUtils metricServiceUtils = null,
    IEnumerable<IMetricOutput> outputs = null,
    RnMetricsConfig config = null)
  {
    return Substitute.For<IServiceProvider>()
      .WithLogger(logger)
      .WithService(dateTime ?? Substitute.For<IDateTimeAbstraction>())
      .WithService(GetMetricServiceUtils(metricServiceUtils, config))
      .WithService(outputs ?? new List<IMetricOutput>());
  }

  public static IMetricServiceUtils GetMetricServiceUtils(
    IMetricServiceUtils utils = null,
    RnMetricsConfig rnMetricsConfig = null)
  {
    return utils ?? CreateMetricServiceUtils(rnMetricsConfig);
  }

  public static IMetricServiceUtils CreateMetricServiceUtils(
    RnMetricsConfig rnMetricsConfig = null)
  {
    var utils = Substitute.For<IMetricServiceUtils>();
    rnMetricsConfig ??= new MetricsConfigBuilder().BuildWithDefaults();

    utils.GetConfiguration().Returns(rnMetricsConfig);

    return utils;
  }

  public static IEnumerable<IMetricOutput> GetDisabledMetricOutputs(params IMetricOutput[] outputs)
  {
    if (outputs.Length == 0)
      outputs = new[] { Substitute.For<IMetricOutput>() };

    var mappedOutputs = new List<IMetricOutput>();

    foreach (var metricOutput in outputs)
    {
      metricOutput.Enabled.Returns(false);
      mappedOutputs.Add(metricOutput);
    }

    return mappedOutputs;
  }

  public static IEnumerable<IMetricOutput> GetEnabledMetricOutputs(params IMetricOutput[] outputs)
  {
    if (outputs.Length == 0)
      outputs = new[] { Substitute.For<IMetricOutput>() };

    var mappedOutputs = new List<IMetricOutput>();

    foreach (var metricOutput in outputs)
    {
      metricOutput.Enabled.Returns(true);
      mappedOutputs.Add(metricOutput);
    }

    return mappedOutputs;
  }
}