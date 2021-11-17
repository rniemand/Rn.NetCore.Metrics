using System;
using NUnit.Framework;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.T1.Tests.TestSupport;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.MetricBuilderBaseTests
{
  [TestFixture]
  public class CoreBuilderTests
  {
    [Test]
    public void SetException_GivenException_ShouldSetTags()
    {
      // arrange
      var builder = new TestMetricBuilder();
      var ex = new Exception("Whoops");

      // act
      var metric = builder.SetException(ex).GetMetric();

      // assert
      Assert.AreEqual("false", metric.Tags[MetricTag.Success]);
      Assert.AreEqual("true", metric.Tags[MetricTag.HasException]);
      Assert.AreEqual(ex.GetType().Name, metric.Tags[MetricTag.ExceptionName]);
    }

    [Test]
    public void SetException_GivenString_ShouldSetTags()
    {
      // arrange
      var builder = new TestMetricBuilder();
      const string ex = "MyException";

      // act
      var metric = builder.SetException(ex).GetMetric();

      // assert
      Assert.AreEqual("false", metric.Tags[MetricTag.Success]);
      Assert.AreEqual("true", metric.Tags[MetricTag.HasException]);
      Assert.AreEqual(ex, metric.Tags[MetricTag.ExceptionName]);
    }

    [Test]
    public void SetSuccess_GivenCalled_ShouldSetTag()
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetSuccess(false).GetMetric();

      // assert
      Assert.AreEqual("false", metric.Tags[MetricTag.Success]);
    }

    [TestCase("tag1", true, false, "true")]
    [TestCase("tag1", "HELLO", false, "hello")]
    [TestCase("tag1", "HELLO", true, "HELLO")]
    [TestCase("tag1", 123, false, "123")]
    [TestCase("tag1", long.MaxValue, false, "9223372036854775807")]
    [TestCase("tag1", 1.2d, false, "1.2")]
    [TestCase("tag1", (byte) 11, false, "11")]
    public void SetObjectTag_GivenCalled_ShouldSetTag(string tag, object value, bool skipToLower, string expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetObjectTag(tag, value, skipToLower).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Tags[tag]);
    }
    
    [TestCase("tag1", "HELLO", false, "hello")]
    [TestCase("tag1", "HELLO", true, "HELLO")]
    public void SetTag_GivenCalled_ShouldSetTag(string tag, string value, bool skipToLower, string expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetTag(tag, value, skipToLower).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Tags[tag]);
    }

    [TestCase("tag1", true, "true")]
    [TestCase("tag1", false, "false")]
    public void SetTag_GivenCalled_ShouldSetTag(string tag, bool value, string expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetTag(tag, value).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Tags[tag]);
    }

    [TestCase("tag1", 1, "1")]
    [TestCase("tag1", -1, "-1")]
    public void SetTag_GivenCalled_ShouldSetTag(string tag, int value, string expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetTag(tag, value).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Tags[tag]);
    }

    [TestCase("field1", 1, 1)]
    [TestCase("field1", -1, -1)]
    public void SetField_GivenCalled_ShouldSetTag(string field, long value, long expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetField(field, value).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Fields[field]);
    }

    [TestCase("field1", 1.0, 1.0)]
    [TestCase("field1", -1.0, -1.0)]
    public void SetField_GivenCalled_ShouldSetTag(string field, double value, double expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetField(field, value).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Fields[field]);
    }

    [TestCase("field1", 1, 1)]
    [TestCase("field1", -1, -1)]
    public void SetField_GivenCalled_ShouldSetTag(string field, float value, float expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetField(field, value).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Fields[field]);
    }

    [TestCase("field1", 1, 1)]
    [TestCase("field1", -1, -1)]
    public void SetField_GivenCalled_ShouldSetTag(string field, int value, int expected)
    {
      // arrange
      var builder = new TestMetricBuilder();

      // act
      var metric = builder.SetField(field, value).GetMetric();

      // assert
      Assert.AreEqual(expected, metric.Fields[field]);
    }
  }
}
