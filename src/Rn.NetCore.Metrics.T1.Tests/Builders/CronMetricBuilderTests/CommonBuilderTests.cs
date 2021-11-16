using System;
using NUnit.Framework;
using Rn.NetCore.Common.Metrics.Builders;
using Rn.NetCore.Common.Metrics.Enums;
using Rn.NetCore.Common.Metrics.Interfaces;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.CronMetricBuilderTests
{
  [TestFixture]
  public class CommonBuilderTests
  {
    [Test]
    public void MarkFailed_GivenCalled_ShouldSetTag()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .MarkFailed()
        .Build();

      // assert
      Assert.AreEqual("false", metric.Tags[MetricTag.Success]);
    }

    [Test]
    public void MarkFailed_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .MarkFailed();

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }


    [Test]
    public void WithException_GivenCalled_ShouldSetTags()
    {
      // arrange
      var ex = new ArgumentException();
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithException(ex)
        .Build();

      // assert
      Assert.AreEqual("false", metric.Tags[MetricTag.Success]);
      Assert.AreEqual("true", metric.Tags[MetricTag.HasException]);
      Assert.AreEqual(ex.GetType().Name, metric.Tags[MetricTag.ExceptionName]);
    }

    [Test]
    public void WithException_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var ex = new ArgumentException();

      // act
      var builder = new CronMetricBuilder()
        .WithException(ex);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }


    [Test]
    public void WithSuccess_GivenCalled_ShouldSetTag()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithSuccess(true)
        .Build();

      // assert
      Assert.AreEqual("true", metric.Tags[MetricTag.Success]);
    }

    [Test]
    public void WithSuccess_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithSuccess(false);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }
  }
}
