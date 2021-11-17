using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.CronMetricBuilderTests
{
  [TestFixture]
  public class ConstructorTests
  {
    private const string CronClass = "CronClass";
    private const string CronMethod = "CronMethod";

    [Test]
    public void Constructor_GivenCalled_ShouldInheritInterfaces()
    {
      // act
      var builder = new CronMetricBuilder();

      // assert
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
      Assert.IsInstanceOf<IMetricBuilder>(builder);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldDefault_Tags()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder.Build();

      // assert
      Assert.AreEqual(string.Empty, metric.Tags[CronMetricBuilder.Tags.CronClass]);
      Assert.AreEqual(string.Empty, metric.Tags[CronMetricBuilder.Tags.CronMethod]);
      Assert.AreEqual(string.Empty, metric.Tags[CronMetricBuilder.Tags.Category]);
      Assert.AreEqual(string.Empty, metric.Tags[CronMetricBuilder.Tags.SubCategory]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag1]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag2]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag3]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag4]);

      Assert.AreEqual("CronMetricBuilder", metric.Tags[MetricTag.Source]);
      Assert.AreEqual("true", metric.Tags[MetricTag.Success]);
      Assert.AreEqual("false", metric.Tags[MetricTag.HasException]);
      Assert.AreEqual(string.Empty, metric.Tags[MetricTag.ExceptionName]);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldDefault_Fields()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder.Build();

      // assert
      Assert.AreEqual(0, metric.Fields[CronMetricBuilder.Fields.QueryCount]);
      Assert.AreEqual(0, metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
      Assert.AreEqual(0, metric.Fields[MetricField.UserId]);
      Assert.AreEqual(0, metric.Fields[MetricField.Int1]);
      Assert.AreEqual(0, metric.Fields[MetricField.Int2]);
      Assert.AreEqual(0, metric.Fields[MetricField.Int3]);
      Assert.AreEqual((long)0, metric.Fields[MetricField.Long1]);
      Assert.AreEqual((long)0, metric.Fields[MetricField.Long2]);
      Assert.AreEqual((long)0, metric.Fields[MetricField.Long3]);
      Assert.AreEqual((long)0, metric.Fields[MetricField.Timing1]);
      Assert.AreEqual((long)0, metric.Fields[MetricField.Timing2]);
      Assert.AreEqual((long)0, metric.Fields[MetricField.Timing3]);

      Assert.AreEqual((long)0, metric.Fields[MetricField.Value]);
      Assert.AreEqual(1, metric.Fields[MetricField.CallCount]);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldDefaultMeasurement()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder.Build();

      // assert
      Assert.AreEqual("cron_job", metric.Measurement);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldDefaultProperties()
    {
      // act
      var builder = new CronMetricBuilder();

      // assert
      Assert.IsFalse(builder.IsNullMetricBuilder);
      Assert.IsNotNull(builder.Build());
      Assert.IsInstanceOf<CoreMetric>(builder.Build());
    }

    [Test]
    public void Constructor_GivenCalledWithClassAndMethod_ShouldSetProperties()
    {
      // arrange
      var builder = new CronMetricBuilder(CronClass, CronMethod);

      // act
      var metric = builder.Build();

      // assert
      Assert.AreEqual(CronClass, metric.Tags[CronMetricBuilder.Tags.CronClass]);
      Assert.AreEqual(CronMethod, metric.Tags[CronMetricBuilder.Tags.CronMethod]);
    }
  }
}
