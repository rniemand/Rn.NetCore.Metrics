using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests;

[TestFixture]
public class CustomLongTests
{
  [Test]
  public void WithCustomLong1_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCustomLong1(12);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithCustomLong2_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCustomLong2(12);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithCustomLong3_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCustomLong3(12);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }


  [Test]
  public void IncrementCustomLong1_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.IncrementCustomLong1();

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void IncrementCustomLong2_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.IncrementCustomLong2();

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void IncrementCustomLong3_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.IncrementCustomLong3();

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }
}