using NUnit.Framework;
using Rn.NetCore.Common.Metrics.Enums;
using Rn.NetCore.Common.Metrics.Models;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.MetricBuilderBaseTests
{
  [TestFixture]
  public class ConstructorTests
  {
    [Test]
    public void Constructor_GivenCalled_ShouldCreateCoreMetric()
    {
      // act
      var builder = new TestMetricBuilder("my_measurement");
      var metric = builder.GetMetric();

      // assert
      Assert.IsNotNull(metric);
      Assert.IsInstanceOf<CoreMetric>(metric);
      Assert.AreEqual("my_measurement", metric.Measurement);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldSetSource()
    {
      // act
      var builder = new TestMetricBuilder("my_measurement");
      var metric = builder.GetMetric();

      // assert
      Assert.IsNotNull(metric);
      Assert.IsInstanceOf<CoreMetric>(metric);
      Assert.AreEqual(nameof(TestMetricBuilder), metric.Tags[MetricTag.Source]);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldDefaultTags()
    {
      // act
      var builder = new TestMetricBuilder("my_measurement");
      var metric = builder.GetMetric();

      // assert
      Assert.AreEqual(nameof(TestMetricBuilder), metric.Tags[MetricTag.Source]);
      Assert.AreEqual("true", metric.Tags[MetricTag.Success]);
      Assert.AreEqual("false", metric.Tags[MetricTag.HasException]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.ExceptionName]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Environment]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Application]);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldDefaultFields()
    {
      // act
      var builder = new TestMetricBuilder("my_measurement");
      var metric = builder.GetMetric();

      // assert
      Assert.AreEqual((long)0, metric.Fields[MetricField.Value]);
      Assert.AreEqual(1, metric.Fields[MetricField.CallCount]);
    }
  }
}
