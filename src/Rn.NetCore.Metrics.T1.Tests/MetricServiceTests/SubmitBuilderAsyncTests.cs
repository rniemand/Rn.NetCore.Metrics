using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Models;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceTests
{
  [TestFixture]
  public class SubmitBuilderAsyncTests
  {
    [Test]
    public async Task SubmitBuilderAsync_GivenDisabled_ShouldDoNothing()
    {
      // arrange
      var builder = Substitute.For<IMetricBuilder>();
      var metricOutputs = TestHelper.GetEnabledMetricOutputs();
      var config = new MetricsConfigBuilder().BuildWithDefaults(false);

      var serviceProvider = TestHelper.GetServiceProvider(
      config: config,
      outputs: metricOutputs
      );

      var metricService = new MetricService(serviceProvider);

      // act
      await metricService.SubmitBuilderAsync(builder);

      // assert
      builder.DidNotReceive().Build();
    }

    [Test]
    public async Task SubmitBuilderAsync_GivenNullMetricBuilder_ShouldDoNothing()
    {
      // arrange
      var builder = Substitute.For<IMetricBuilder>();
      var metricOutputs = TestHelper.GetEnabledMetricOutputs();
      var config = new MetricsConfigBuilder().BuildWithDefaults(true);

      builder.IsNullMetricBuilder.Returns(true);

      var serviceProvider = TestHelper.GetServiceProvider(
      config: config,
      outputs: metricOutputs
      );

      var metricService = new MetricService(serviceProvider);

      // act
      await metricService.SubmitBuilderAsync(builder);

      // assert
      builder.DidNotReceive().Build();
    }

    [Test]
    public async Task SubmitBuilderAsync_GivenNoEnabledOutputs_ShouldDoNothing()
    {
      // arrange
      var builder = Substitute.For<IMetricBuilder>();
      var metricOutputs = TestHelper.GetDisabledMetricOutputs();
      var config = new MetricsConfigBuilder().BuildWithDefaults(true);

      builder.IsNullMetricBuilder.Returns(false);

      var serviceProvider = TestHelper.GetServiceProvider(
      config: config,
      outputs: metricOutputs
      );

      var metricService = new MetricService(serviceProvider);

      // act
      await metricService.SubmitBuilderAsync(builder);

      // assert
      builder.DidNotReceive().Build();
    }

    [Test]
    public async Task SubmitBuilderAsync_GivenEnabledOutputs_ShouldCallBuild()
    {
      // arrange
      var builder = Substitute.For<IMetricBuilder>();
      var metricOutputs = TestHelper.GetEnabledMetricOutputs();
      var config = new MetricsConfigBuilder().BuildWithDefaults(true);
      var builtMetric = new CoreMetricBuilder()
      .WithDefaults()
      .Build();

      builder.IsNullMetricBuilder.Returns(false);
      builder.Build().Returns(builtMetric);

      var serviceProvider = TestHelper.GetServiceProvider(
      config: config,
      outputs: metricOutputs
      );

      var metricService = new MetricService(serviceProvider);

      // act
      await metricService.SubmitBuilderAsync(builder);

      // assert
      builder.Received(1).Build();
    }

    [Test]
    public async Task SubmitBuilderAsync_GivenEnabledOutput_ShouldCallSubmitMetric()
    {
      // arrange
      var builder = Substitute.For<IMetricBuilder>();
      var output1 = Substitute.For<IMetricOutput>();
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);
      var config = new MetricsConfigBuilder().BuildWithDefaults(true);
      var builtMetric = new CoreMetricBuilder()
      .WithDefaults()
      .Build();

      builder.IsNullMetricBuilder.Returns(false);
      builder.Build().Returns(builtMetric);

      var serviceProvider = TestHelper.GetServiceProvider(
      config: config,
      outputs: metricOutputs
      );

      var metricService = new MetricService(serviceProvider);

      // act
      await metricService.SubmitBuilderAsync(builder);

      // assert
      await output1.Received(1).SubmitMetric(builtMetric);
    }

    [Test]
    public async Task SubmitBuilderAsync_GivenEnabledOutput_ShouldCallFinalizeMetric()
    {
      // arrange
      var builder = Substitute.For<IMetricBuilder>();
      var output1 = Substitute.For<IMetricOutput>();
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);

      var config = new MetricsConfigBuilder()
        .WithDefaults()
        .WithEnabled(true)
        .WithApplication("my_app")
        .WithOverride("my_metric", "my_replaced_metric")
        .Build();

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .WithMeasurement("my_metric")
        .Build();

      builder.IsNullMetricBuilder.Returns(false);
      builder.Build().Returns(metric);

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs
      );

      var metricService = new MetricService(serviceProvider);

      // act
      await metricService.SubmitBuilderAsync(builder);

      // assert
      await output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Measurement == "my_app/my_replaced_metric"
      ));
    }
  }
}
