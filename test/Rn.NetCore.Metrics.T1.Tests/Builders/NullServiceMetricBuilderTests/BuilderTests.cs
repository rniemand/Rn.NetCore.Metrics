using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests;

[TestFixture]
public class BuilderTests
{
  [Test]
  public void ForService_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.ForService("Service", "Method");

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithCategory_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithCategory("Category", "SubCategory");

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithQueryCount_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithQueryCount(1);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void IncrementQueryCount_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.IncrementQueryCount(10);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithResultsCount_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithResultsCount(10);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void IncrementResultsCount_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.IncrementResultsCount(10);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void CountResult_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.CountResult();

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithUserId_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var afterCall = builder.WithUserId(1);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }
}