using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Metrics.Interfaces;
using Rn.NetCore.Common.Metrics.Models;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceTests
{
  [TestFixture]
  public class SubmitMetricAsyncTests
  {
    [Test]
    public async Task SubmitMetricAsync_GivenDisabled_ShouldDoNothing()
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);
      var config = new MetricsConfigBuilder().BuildWithDefaults(false);

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .Build();

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs
      );

      var metricService = new Common.Metrics.MetricService(serviceProvider);

      // act
      await metricService.SubmitMetricAsync(metric);

      // assert
      await output1.DidNotReceive().SubmitMetric(metric);
    }

    [Test]
    public async Task SubmitMetricAsync_GivenNoEnabledOutputs_ShouldDoNothing()
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var metricOutputs = TestHelper.GetDisabledMetricOutputs(output1);
      var config = new MetricsConfigBuilder().BuildWithDefaults(true);

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .Build();

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs
      );

      var metricService = new Common.Metrics.MetricService(serviceProvider);

      // act
      await metricService.SubmitMetricAsync(metric);

      // assert
      await output1.DidNotReceive().SubmitMetric(metric);
    }

    [Test]
    public async Task SubmitMetricAsync_GivenEnabledOutput_ShouldCallSubmitMetric()
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);
      var config = new MetricsConfigBuilder().BuildWithDefaults(true);

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .Build();

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs
      );

      var metricService = new Common.Metrics.MetricService(serviceProvider);

      // act
      await metricService.SubmitMetricAsync(metric);

      // assert
      await output1.Received(1).SubmitMetric(metric);
    }

    [Test]
    public async Task SubmitMetricAsync_GivenEnabledOutput_ShouldCallFinalizeMetric()
    {
      // arrange
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

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs
      );

      var metricService = new Common.Metrics.MetricService(serviceProvider);

      // act
      await metricService.SubmitMetricAsync(metric);

      // assert
      await output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Measurement == "my_app/my_replaced_metric"
      ));
    }
  }
}
