using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests;

[TestFixture]
public class CustomTagTests
{
  [Test]
  public void WithCustomTag1_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCustomTag1("Value");

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithCustomTag2_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCustomTag2("Value");

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithCustomTag3_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCustomTag3("Value");

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithCustomTag4_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCustomTag4("Value");

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }
}