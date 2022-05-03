using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Enums;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.CronMetricBuilderTests;

[TestFixture]
public class CustomLongTests
{
  [Test]
  public void WithCustomLong1_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .WithCustomLong1(33)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long1]);
    Assert.AreEqual(33, metric.Fields[MetricField.Long1]);
  }

  [Test]
  public void WithCustomLong1_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .WithCustomLong1(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomLong1_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .IncrementCustomLong1(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long1]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long1]);
  }

  [Test]
  public void IncrementCustomLong1_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .IncrementCustomLong1(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomLong2_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .WithCustomLong2(33)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long2]);
    Assert.AreEqual(33, metric.Fields[MetricField.Long2]);
  }

  [Test]
  public void WithCustomLong2_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .WithCustomLong2(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomLong2_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .IncrementCustomLong2(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long2]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long2]);
  }

  [Test]
  public void IncrementCustomLong2_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .IncrementCustomLong2(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomLong3_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .WithCustomLong3(33)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long3]);
    Assert.AreEqual(33, metric.Fields[MetricField.Long3]);
  }

  [Test]
  public void WithCustomLong3_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .WithCustomLong3(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomLong3_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .IncrementCustomLong3(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long3]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long3]);
  }

  [Test]
  public void IncrementCustomLong3_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .IncrementCustomLong3(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }
}