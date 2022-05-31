using System.Threading;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Extensions;

namespace Rn.NetCore.Metrics.T1.Tests.Extensions;

[TestFixture]
internal class CoreMetricBuilderExtensionsTests
{
  [Test]
  public void WithCustomTag1_GivenCalled_ShouldAppendCustomTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomTag1("value1")
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["custom_tag1"], Is.EqualTo("value1"));
  }

  [Test]
  public void WithCustomTag2_GivenCalled_ShouldAppendCustomTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomTag2("value2")
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["custom_tag2"], Is.EqualTo("value2"));
  }

  [Test]
  public void WithCustomTag3_GivenCalled_ShouldAppendCustomTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomTag3("value3")
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["custom_tag3"], Is.EqualTo("value3"));
  }

  [Test]
  public void WithCustomTag4_GivenCalled_ShouldAppendCustomTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomTag4("value4")
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["custom_tag4"], Is.EqualTo("value4"));
  }

  [Test]
  public void WithCustomTag5_GivenCalled_ShouldAppendCustomTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomTag5("value5")
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["custom_tag5"], Is.EqualTo("value5"));
  }

  [Test]
  public void WithTag_GivenCalled_ShouldAppendCustomTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithTag("tag", "value")
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["tag"], Is.EqualTo("value"));
  }

  [Test]
  public void WithCustomInt1_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomInt1(1)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_int1"], Is.EqualTo(1));
  }

  [Test]
  public void WithCustomInt2_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomInt2(2)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_int2"], Is.EqualTo(2));
  }

  [Test]
  public void WithCustomInt3_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomInt3(3)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_int3"], Is.EqualTo(3));
  }

  [Test]
  public void WithCustomInt4_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomInt4(4)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_int4"], Is.EqualTo(4));
  }

  [Test]
  public void WithCustomInt5_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomInt5(5)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_int5"], Is.EqualTo(5));
  }

  [Test]
  public void WitInt_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WitInt("field", 5)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["field"], Is.EqualTo(5));
  }

  [Test]
  public void WithCustomLong1_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomLong1(1)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_long1"], Is.EqualTo(1));
  }

  [Test]
  public void WithCustomLong2_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomLong2(2)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_long2"], Is.EqualTo(2));
  }

  [Test]
  public void WithCustomLong3_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomLong3(3)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_long3"], Is.EqualTo(3));
  }

  [Test]
  public void WithCustomLong4_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomLong4(4)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_long4"], Is.EqualTo(4));
  }

  [Test]
  public void WithCustomLong5_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithCustomLong5(5)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_long5"], Is.EqualTo(5));
  }

  [Test]
  public void WithLong_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithLong("field", 5)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["field"], Is.EqualTo(5));
  }

  [Test]
  public void WithUserId_GivenCalled_ShouldAppendCustomField()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithUserId(5)
      .Build();

    // Assert
    Assert.That(coreMetric.Fields["user_id"], Is.EqualTo(5));
  }

  [Test]
  public void MarkFailed_GivenCalled_ShouldUpdateCorrectTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .MarkFailed()
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["success"], Is.EqualTo("false"));
  }

  [Test]
  public void MarkSuccess_GivenCalled_ShouldUpdateCorrectTag()
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .MarkSuccess()
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["success"], Is.EqualTo("true"));
  }

  [TestCase(true, "true")]
  [TestCase(false, "false")]
  public void WithSuccess_GivenCalled_ShouldUpdateCorrectTag(bool value, string expected)
  {
    // Act
    var coreMetric = new ServiceMetricBuilder()
      .WithSuccess(value)
      .Build();

    // Assert
    Assert.That(coreMetric.Tags["success"], Is.EqualTo(expected));
  }

  [Test]
  public void WithCustomTiming1_GivenCalled_ShouldReturnTimingToken()
  {
    // Arrange
    var builder = new ServiceMetricBuilder();

    // Act
    using (builder.WithCustomTiming1())
    {
      Thread.Sleep(5);
    }

    var coreMetric = builder.Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_timing1"], Is.GreaterThanOrEqualTo(5));
  }

  [Test]
  public void WithCustomTiming2_GivenCalled_ShouldReturnTimingToken()
  {
    // Arrange
    var builder = new ServiceMetricBuilder();

    // Act
    using (builder.WithCustomTiming2())
    {
      Thread.Sleep(5);
    }

    var coreMetric = builder.Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_timing2"], Is.GreaterThanOrEqualTo(5));
  }

  [Test]
  public void WithCustomTiming3_GivenCalled_ShouldReturnTimingToken()
  {
    // Arrange
    var builder = new ServiceMetricBuilder();

    // Act
    using (builder.WithCustomTiming3())
    {
      Thread.Sleep(5);
    }

    var coreMetric = builder.Build();

    // Assert
    Assert.That(coreMetric.Fields["custom_timing3"], Is.GreaterThanOrEqualTo(5));
  }

  [Test]
  public void WithTiming_GivenCalled_ShouldReturnTimingToken()
  {
    // Arrange
    var builder = new ServiceMetricBuilder();

    // Act
    using (builder.WithTiming())
    {
      Thread.Sleep(5);
    }

    var coreMetric = builder.Build();

    // Assert
    Assert.That(coreMetric.Fields["value"], Is.GreaterThanOrEqualTo(5));
  }

  [Test]
  public void WithTiming_GivenFieldName_ShouldReturnTimingToken()
  {
    // Arrange
    var builder = new ServiceMetricBuilder();

    // Act
    using (builder.WithTiming("myTiming"))
    {
      Thread.Sleep(5);
    }

    var coreMetric = builder.Build();

    // Assert
    Assert.That(coreMetric.Fields["myTiming"], Is.GreaterThanOrEqualTo(5));
  }
}
