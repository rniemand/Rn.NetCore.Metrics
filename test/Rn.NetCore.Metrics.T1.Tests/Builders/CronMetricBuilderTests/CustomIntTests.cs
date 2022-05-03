using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Enums;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.CronMetricBuilderTests;

[TestFixture]
public class CustomIntTests
{
  [Test]
  public void WithCustomInt1_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .WithCustomInt1(33)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int1]);
    Assert.AreEqual(33, metric.Fields[MetricField.Int1]);
  }

  [Test]
  public void WithCustomInt1_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .WithCustomInt1(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt1_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .IncrementCustomInt1(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int1]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int1]);
  }

  [Test]
  public void IncrementCustomInt1_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .IncrementCustomInt1(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomInt2_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .WithCustomInt2(33)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int2]);
    Assert.AreEqual(33, metric.Fields[MetricField.Int2]);
  }

  [Test]
  public void WithCustomInt2_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .WithCustomInt2(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt2_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .IncrementCustomInt2(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int2]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int2]);
  }

  [Test]
  public void IncrementCustomInt2_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .IncrementCustomInt2(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomInt3_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .WithCustomInt3(33)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int3]);
    Assert.AreEqual(33, metric.Fields[MetricField.Int3]);
  }

  [Test]
  public void WithCustomInt3_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .WithCustomInt3(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt3_GivenCalled_ShouldSetField()
  {
    // arrange
    var builder = new CronMetricBuilder();

    // act
    var metric = builder
      .IncrementCustomInt3(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int3]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int3]);
  }

  [Test]
  public void IncrementCustomInt3_GivenCalled_ShouldReturnBuilder()
  {
    // act
    var builder = new CronMetricBuilder()
      .IncrementCustomInt3(2);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<ICronMetricBuilder>(builder);
  }
}