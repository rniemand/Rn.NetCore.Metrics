using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.LibRoot.MetricServiceTests;

[TestFixture]
public class FinalizeMetricTests
{
  [Test]
  public async Task FinalizeMetric_GivenHasMetricOverride_ShouldReplaceMeasurement()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .WithMetricOverride("override_me", "all_done")
      .WithTemplate("{measurement}")
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);

    var metric = new CoreMetric("override_me");

    var metricService = TestHelper.GetMetricService(
      config: metricsConfig,
      outputs: new List<IMetricOutput> {output});

    // act
    await metricService.SubmitAsync(metric);

    // assert
    await output.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
      m.Measurement == "all_done"));
  }

  [Test]
  public async Task FinalizeMetric_GivenCalled_ShouldSetMetricDateTime()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    var dateTime = Substitute.For<IDateTimeAbstraction>();
    var baseDate = DateTime.UtcNow;
    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    dateTime.UtcNow.Returns(baseDate);

    var metric = new CoreMetric("measurement");

    var metricService = TestHelper.GetMetricService(
      config: metricsConfig,
      outputs: new List<IMetricOutput> { output },
      dateTime: dateTime);

    // act
    await metricService.SubmitAsync(metric);

    // assert
    await output.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
      m.UtcTimestamp == baseDate));
  }

  [Test]
  public async Task FinalizeMetric_GivenCalled_ShouldSetEnvironment()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .WithEnvironment("MyEnvironment")
      .Build();

    var dateTime = Substitute.For<IDateTimeAbstraction>();
    var baseDate = DateTime.UtcNow;
    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    dateTime.UtcNow.Returns(baseDate);

    var metric = new CoreMetric("override_me");

    var metricService = TestHelper.GetMetricService(
      config: metricsConfig,
      outputs: new List<IMetricOutput> { output },
      dateTime: dateTime);

    // act
    await metricService.SubmitAsync(metric);

    // assert
    await output.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
      m.Tags["environment"] == "myenvironment"));
  }

  [Test]
  public async Task FinalizeMetric_GivenCalled_ShouldSetApplication()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .WithApplication("MyApplication")
      .Build();

    var dateTime = Substitute.For<IDateTimeAbstraction>();
    var baseDate = DateTime.UtcNow;
    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    dateTime.UtcNow.Returns(baseDate);

    var metric = new CoreMetric("override_me");

    var metricService = TestHelper.GetMetricService(
      config: metricsConfig,
      outputs: new List<IMetricOutput> { output },
      dateTime: dateTime);

    // act
    await metricService.SubmitAsync(metric);

    // assert
    await output.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
      m.Tags["application"] == "myapplication"));
  }
}
