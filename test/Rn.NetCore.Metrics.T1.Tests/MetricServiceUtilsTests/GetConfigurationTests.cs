using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Configuration;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceUtilsTests;

[TestFixture]
public class GetConfigurationTests
{
  [Test]
  public void GetConfiguration_GivenCalled_ShouldResolveConfigSection()
  {
    // arrange
    var configuration = Substitute.For<IConfiguration>();

    var metricServiceUtils = TestHelper.GetMetricServiceUtils(
      configuration: configuration
    );

    // act
    metricServiceUtils.GetConfiguration();

    // assert
    configuration.Received(1).GetSection(RnMetricsConfig.ConfigKey);
  }

  [Test]
  public void GetConfiguration_GivenSectionNotFound_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<MetricServiceUtils>>();
    var configuration = new ConfigurationBuilder().Build();

    var metricServiceUtils = TestHelper.GetMetricServiceUtils(
      configuration: configuration,
      logger: logger);
      
    // act
    metricServiceUtils.GetConfiguration();

    // assert
    logger.Received(1).LogWarning(
      "Metrics disabled (config '{key}' missing)",
      RnMetricsConfig.ConfigKey);
  }

  [Test]
  public void GetConfiguration_GivenSectionFound_ShouldCallBind()
  {
    // arrange
    var configuration = Substitute.For<IConfiguration>();
    var section = Substitute.For<IConfigurationSection>();

    configuration.GetSection(RnMetricsConfig.ConfigKey).Returns(section);

    var metricServiceUtils = TestHelper.GetMetricServiceUtils(
      configuration: configuration
    );

    // act
    metricServiceUtils.GetConfiguration();

    // assert
    section.Received(1).Bind(Arg.Any<RnMetricsConfig>());
  }
}
