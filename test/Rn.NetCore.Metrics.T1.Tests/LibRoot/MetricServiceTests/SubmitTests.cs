using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.LibRoot.MetricServiceTests;

[TestFixture]
public class SubmitTests
{
  [Test]
  public void SubmitMetricBuilder_GivenMetricsDisabled_ShouldDoNothing()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(false)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var metricBuilder = new ServiceMetricBuilder();

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    service.Submit(metricBuilder);

    // assert
    output.DidNotReceive().SubmitMetric(Arg.Any<CoreMetric>());
  }

  [Test]
  public void SubmitMetric_GivenMetricsDisabled_ShouldDoNothing()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(false)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var coreMetric = new ServiceMetricBuilder().Build();

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    service.Submit(coreMetric);

    // assert
    output.DidNotReceive().SubmitMetric(Arg.Any<CoreMetric>());
  }

  [Test]
  public void SubmitMetricBuilder_GivenMetricsEnabled_ShouldCallSubmitMetric()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var builder = new ServiceMetricBuilder();

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    service.Submit(builder);

    // assert
    output.Received(1).SubmitMetric(Arg.Any<CoreMetric>());
  }

  [Test]
  public void SubmitMetric_GivenMetricsEnabled_ShouldCallSubmitMetric()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var coreMetric = new CoreMetric("metric");

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    service.Submit(coreMetric);

    // assert
    output.Received(1).SubmitMetric(coreMetric);
  }

  [Test]
  public async Task SubmitMetricBuilderAsync_GivenMetricsDisabled_ShouldDoNothing()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(false)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var metricBuilder = new ServiceMetricBuilder();

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    await service.SubmitAsync(metricBuilder);

    // assert
    await output.DidNotReceive().SubmitMetric(Arg.Any<CoreMetric>());
  }

  [Test]
  public async Task SubmitMetricBuilderAsync_GivenMetricsEnabled_ShouldCallSubmitMetric()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var metricBuilder = new ServiceMetricBuilder();

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    await service.SubmitAsync(metricBuilder);

    // assert
    await output.Received(1).SubmitMetric(Arg.Any<CoreMetric>());
  }

  [Test]
  public async Task SubmitMetricAsyncAsync_GivenMetricsDisabled_ShouldDoNothing()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(false)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var coreMetric = new CoreMetric("metric");

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    await service.SubmitAsync(coreMetric);

    // assert
    await output.DidNotReceive().SubmitMetric(Arg.Any<CoreMetric>());
  }

  [Test]
  public async Task SubmitMetricAsyncAsync_GivenMetricsEnabled_ShouldCallSubmitMetric()
  {
    // arrange
    var metricsConfig = new RnMetricsConfigBuilder()
      .WithEnabled(true)
      .Build();

    var output = Substitute.For<IMetricOutput>();
    output.Enabled.Returns(true);
    var coreMetric = new CoreMetric("metric");

    var service = TestHelper.GetMetricService(
      outputs: new List<IMetricOutput> { output },
      config: metricsConfig);

    // act
    await service.SubmitAsync(coreMetric);

    // assert
    await output.Received(1).SubmitMetric(coreMetric);
  }
}
