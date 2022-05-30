using System;
using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.LibRoot.MetricServiceTests;

[TestFixture]
public class LoadMetricOutputsTests
{
  [Test]
  public void LoadMetricOutputs_GivenNoEnabledOutputs_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<MetricService>>();
    var config = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    // act
    TestHelper.GetMetricService(
      logger: logger,
      config: config);

    // assert
    logger.Received(1).LogWarning("No enabled outputs, disabling metric service");
  }

  [Test]
  public void LoadMetricOutputs_GivenNoEnabledOutputs_ShouldDisableMetricService()
  {
    // arrange
    var config = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    // act
    Assert.That(config.Enabled, Is.True);
    TestHelper.GetMetricService(config: config);

    // assert
    Assert.That(config.Enabled, Is.False);
  }

  [Test]
  public void LoadMetricOutputs_GivenEnabledOutputs_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<MetricService>>();

    var config = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .WithEnableConsoleOutput(true)
      .Build();

    var outputs = new List<IMetricOutput>
    {
      new ConsoleMetricOutput(config),
      new ConsoleMetricOutput(config)
    };

    // act
    TestHelper.GetMetricService(
      config: config,
      logger: logger,
      outputs: outputs);

    // assert
    logger.Received(1).LogInformation("Metric service running with {count} output(s)", 2);
  }

  [Test]
  public void LoadMetricOutputs_GivenExceptionThrown_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<MetricService>>();
    var output = Substitute.For<IMetricOutput>();
    var outputs = new List<IMetricOutput> { output };
    var ex = new Exception("Whoops");

    var config = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    output.Enabled.Throws(ex);

    // act
    TestHelper.GetMetricService(
      config: config,
      logger: logger,
      outputs: outputs);

    // assert
    logger.Received(1).LogError(ex, "Error loading metric outputs: {message}. {stack}",
      ex.Message,
      ex.HumanStackTrace());
  }

  [Test]
  public void LoadMetricOutputs_GivenExceptionThrown_ShouldDisableMetricService()
  {
    // arrange
    var output = Substitute.For<IMetricOutput>();
    var outputs = new List<IMetricOutput> { output };
    var ex = new Exception("Whoops");

    var config = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    output.Enabled.Throws(ex);

    // act
    Assert.That(config.Enabled, Is.True);
    TestHelper.GetMetricService(
      config: config,
      outputs: outputs);

    // assert
    Assert.That(config.Enabled, Is.False);
  }
}
