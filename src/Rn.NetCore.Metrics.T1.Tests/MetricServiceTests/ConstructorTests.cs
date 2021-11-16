using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Common.Metrics.Interfaces;
using Rn.NetCore.Metrics.T1.Tests.TestSupport;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceTests
{
  [TestFixture]
  public class ConstructorTests
  {
    [Test]
    public void MetricService_Given_Constructed_ShouldResolve_RequiredServices()
    {
      // arrange
      var serviceProvider = TestHelper.GetServiceProvider();

      // act
      var _ = new MetricService(serviceProvider);

      // assert
      serviceProvider.Received(1).GetService(typeof(ILoggerAdapter<MetricService>));
      serviceProvider.Received(1).GetService(typeof(IDateTimeAbstraction));
      serviceProvider.Received(1).GetService(typeof(IMetricServiceUtils));
    }

    [Test]
    public void MetricService_Given_Disabled_ShouldLog()
    {
      // arrange
      var logger = Substitute.For<ILoggerAdapter<MetricService>>();
      var metricServiceUtils = TestHelper.CreateMetricServiceUtils(
        new MetricsConfigBuilder().BuildWithDefaults(false)
      );

      var serviceProvider = TestHelper.GetServiceProvider(
        metricServiceUtils: metricServiceUtils,
        logger: logger
      );

      // act
      var _ = new MetricService(serviceProvider);

      // assert
      logger.Received(1).Info("Metric service disabled (via config)");
    }

    [Test]
    public void MetricService_Given_Enabled_ShouldLoad_MetricOutputs()
    {
      // arrange
      var metricServiceUtils = TestHelper.CreateMetricServiceUtils(
        new MetricsConfigBuilder().BuildWithDefaults(true)
      );

      var serviceProvider = TestHelper.GetServiceProvider(
        metricServiceUtils: metricServiceUtils
      );

      // act
      var _ = new MetricService(serviceProvider);

      // assert
      serviceProvider.Received(1).GetService(typeof(IEnumerable<IMetricOutput>));
    }

    [Test]
    public void MetricService_Given_NoEnabledOutputs_ShouldLog()
    {
      // arrange
      var logger = Substitute.For<ILoggerAdapter<MetricService>>();
      var metricServiceUtils = TestHelper.CreateMetricServiceUtils(
        new MetricsConfigBuilder().BuildWithDefaults(true)
      );

      var serviceProvider = TestHelper.GetServiceProvider(
        metricServiceUtils: metricServiceUtils,
        logger: logger,
        outputs: TestHelper.GetDisabledMetricOutputs()
      );

      // act
      var _ = new MetricService(serviceProvider);

      // assert
      logger.Received(1).Warning("No enabled outputs, disabling metric service");
    }

    [Test]
    public void MetricService_Given_NoEnabledOutputs_ShouldSet_EnabledFalse()
    {
      // arrange
      var metricsConfig = new MetricsConfigBuilder().BuildWithDefaults(true);
      var metricServiceUtils = TestHelper.CreateMetricServiceUtils(metricsConfig);

      var serviceProvider = TestHelper.GetServiceProvider(
        metricServiceUtils: metricServiceUtils,
        outputs: TestHelper.GetDisabledMetricOutputs()
      );

      // act
      Assert.IsTrue(metricsConfig.Enabled);
      var _ = new MetricService(serviceProvider);

      // assert
      Assert.IsFalse(metricsConfig.Enabled);
    }

    [Test]
    public void MetricService_Given_EnabledOutputs_ShouldLog()
    {
      // arrange
      var logger = Substitute.For<ILoggerAdapter<MetricService>>();
      var metricServiceUtils = TestHelper.CreateMetricServiceUtils(
        new MetricsConfigBuilder()
          .WithDefaults()
          .WithEnabled(true)
          .Build()
      );

      var serviceProvider = TestHelper.GetServiceProvider(
        metricServiceUtils: metricServiceUtils,
        logger: logger,
        outputs: TestHelper.GetEnabledMetricOutputs()
      );

      // act
      var _ = new MetricService(serviceProvider);

      // assert
      logger.Received(1).Info(
        "Metric service running with {count} output(s)",
        1
      );
    }
  }
}
