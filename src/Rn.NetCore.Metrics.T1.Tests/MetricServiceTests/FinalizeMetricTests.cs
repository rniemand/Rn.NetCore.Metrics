using System;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceTests
{
  [TestFixture]
  public class FinalizeMetricTests
  {
    [Test]
    public void FinalizeMetric_GivenNoMetricOverride_ShouldUseMetricMeasurement()
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
        .WithMeasurement("default")
        .Build();

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs
      );

      var metricService = new MetricService(serviceProvider);

      // act
      metricService.SubmitMetric(metric);

      // assert
      output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Measurement == "my_app/default"
      ));
    }

    [Test]
    public void FinalizeMetric_GivenMetricOverride_ShouldUseOverrideMeasurement()
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

      var metricService = new MetricService(serviceProvider);

      // act
      metricService.SubmitMetric(metric);

      // assert
      output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Measurement == "my_app/my_replaced_metric"
      ));
    }

    [Test]
    public void FinalizeMetric_GivenCalled_ShouldUseCurrentUtcDateTime()
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var dateTime = Substitute.For<IDateTimeAbstraction>();
      var baseDate = DateTime.UtcNow;
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);
      var config = new MetricsConfigBuilder().BuildWithDefaults(true);

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .WithMeasurement("my_metric")
        .Build();

      dateTime.UtcNow.Returns(baseDate);

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs,
        dateTime: dateTime
      );

      var metricService = new MetricService(serviceProvider);

      // act
      metricService.SubmitMetric(metric);

      // assert
      output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.UtcTimestamp == baseDate
      ));
    }

    [Test]
    public void FinalizeMetric_GivenCalled_ShouldSetEnvironmentTag()
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var dateTime = Substitute.For<IDateTimeAbstraction>();
      var baseDate = DateTime.UtcNow;
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);

      var config = new MetricsConfigBuilder()
        .WithDefaults()
        .WithEnabled(true)
        .WithEnvironment("my_awesome_env")
        .Build();

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .WithMeasurement("my_metric")
        .Build();

      dateTime.UtcNow.Returns(baseDate);

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs,
        dateTime: dateTime
      );

      var metricService = new MetricService(serviceProvider);

      // act
      metricService.SubmitMetric(metric);

      // assert
      output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Tags[MetricTag.Environment] == "my_awesome_env"
      ));
    }

    [Test]
    public void FinalizeMetric_GivenCalled_ShouldSetApplicationTag()
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var dateTime = Substitute.For<IDateTimeAbstraction>();
      var baseDate = DateTime.UtcNow;
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);

      var config = new MetricsConfigBuilder()
        .WithDefaults()
        .WithEnabled(true)
        .WithApplication("my_awesome_app")
        .Build();

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .WithMeasurement("my_metric")
        .Build();

      dateTime.UtcNow.Returns(baseDate);

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs,
        dateTime: dateTime
      );

      var metricService = new MetricService(serviceProvider);

      // act
      metricService.SubmitMetric(metric);

      // assert
      output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Tags[MetricTag.Application] == "my_awesome_app"
      ));
    }

    [Test]
    public void FinalizeMetric_GivenCalled_ShouldGenerateFinalMeasurement()
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var dateTime = Substitute.For<IDateTimeAbstraction>();
      var baseDate = DateTime.UtcNow;
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);

      var config = new MetricsConfigBuilder()
        .WithDefaults()
        .WithEnabled(true)
        .WithApplication("my_awesome_app")
        .Build();

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .WithMeasurement("my_metric")
        .Build();

      dateTime.UtcNow.Returns(baseDate);

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs,
        dateTime: dateTime
      );

      var metricService = new MetricService(serviceProvider);

      // act
      metricService.SubmitMetric(metric);

      // assert
      output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Measurement == "my_awesome_app/my_metric"
      ));
    }

    [TestCase("{app}/{measurement}", "my_awesome_app/my_metric")]
    [TestCase("{app}", "my_awesome_app")]
    [TestCase("{measurement}", "my_metric")]
    public void FinalizeMetric_GivenCalled_ShouldFollowMetricTemplate(string template, string expected)
    {
      // arrange
      var output1 = Substitute.For<IMetricOutput>();
      var dateTime = Substitute.For<IDateTimeAbstraction>();
      var baseDate = DateTime.UtcNow;
      var metricOutputs = TestHelper.GetEnabledMetricOutputs(output1);

      var config = new MetricsConfigBuilder()
        .WithDefaults()
        .WithEnabled(true)
        .WithTemplate(template)
        .WithApplication("my_awesome_app")
        .Build();

      var metric = new CoreMetricBuilder()
        .WithDefaults()
        .WithMeasurement("my_metric")
        .Build();

      dateTime.UtcNow.Returns(baseDate);

      var serviceProvider = TestHelper.GetServiceProvider(
        config: config,
        outputs: metricOutputs,
        dateTime: dateTime
      );

      var metricService = new MetricService(serviceProvider);

      // act
      metricService.SubmitMetric(metric);

      // assert
      output1.Received(1).SubmitMetric(Arg.Is<CoreMetric>(m =>
        m.Measurement == expected
      ));
    }
  }
}
