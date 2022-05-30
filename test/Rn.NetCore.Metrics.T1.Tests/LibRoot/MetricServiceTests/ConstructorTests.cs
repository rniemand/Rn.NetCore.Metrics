using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.LibRoot.MetricServiceTests;

[TestFixture]
public class ConstructorTests
{
  [Test]
  public void Constructor_GivenMetricsDisabled_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<MetricService>>();
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(false)
      .Build();

    // act
    TestHelper.GetMetricService(
      logger: logger,
      config: metricsConfig);

    // assert
    logger.Received(1).LogInformation("Metric service disabled (via config)");
  }
}
