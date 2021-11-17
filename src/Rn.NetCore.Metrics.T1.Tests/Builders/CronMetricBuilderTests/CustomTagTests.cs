using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Enums;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.CronMetricBuilderTests
{
  [TestFixture]
  public class CustomTagTests
  {
    [Test]
    public void WithCustomTag1_GivenCalled_ShouldSetTag()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithCustomTag1(true)
        .Build();

      // assert
      Assert.AreEqual("true", metric.Tags[MetricTag.Tag1]);
    }

    [Test]
    public void WithCustomTag1_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithCustomTag1(false);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void WithCustomTag2_GivenCalled_ShouldSetTag()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithCustomTag2(1)
        .Build();

      // assert
      Assert.AreEqual("1", metric.Tags[MetricTag.Tag2]);
    }

    [Test]
    public void WithCustomTag2_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithCustomTag2(2);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void WithCustomTag3_GivenCalled_ShouldSetTag()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithCustomTag3("hi")
        .Build();

      // assert
      Assert.AreEqual("hi", metric.Tags[MetricTag.Tag3]);
    }

    [Test]
    public void WithCustomTag3_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithCustomTag3("Hi");

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void WithCustomTag4_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithCustomTag4("New", true);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
      Assert.AreEqual("New", builder.Build().Tags[MetricTag.Tag4]);
    }
  }
}
