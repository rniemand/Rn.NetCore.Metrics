using System;
using System.Collections.Generic;
using NSubstitute;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Common.Metrics.Configuration;
using Rn.NetCore.Common.Metrics.Interfaces;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceTests
{
  public static class TestHelper
  {
    public static IServiceProvider GetServiceProvider(
      ILoggerAdapter<Common.Metrics.MetricService> logger = null,
      IDateTimeAbstraction dateTime = null,
      Common.Metrics.IMetricServiceUtils metricServiceUtils = null,
      IEnumerable<IMetricOutput> outputs = null,
      MetricsConfig config = null)
    {
      return new ServiceProviderBuilder()
        .WithLogger(logger)
        .WithService(dateTime ?? Substitute.For<IDateTimeAbstraction>())
        .WithService(GetMetricServiceUtils(metricServiceUtils, config))
        .WithService(outputs ?? new List<IMetricOutput>())
        .Build();
    }

    public static Common.Metrics.IMetricServiceUtils GetMetricServiceUtils(
      Common.Metrics.IMetricServiceUtils utils = null,
      MetricsConfig metricsConfig = null)
    {
      return utils ?? CreateMetricServiceUtils(metricsConfig);
    }

    public static Common.Metrics.IMetricServiceUtils CreateMetricServiceUtils(
      MetricsConfig metricsConfig = null)
    {
      var utils = Substitute.For<Common.Metrics.IMetricServiceUtils>();
      metricsConfig ??= new MetricsConfigBuilder().BuildWithDefaults();

      utils.GetConfiguration().Returns(metricsConfig);

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
}
