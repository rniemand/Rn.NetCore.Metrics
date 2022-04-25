using System;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullCronMetricBuilderTests;

[TestFixture]
public class CommonBuilderTests
{
  [Test]
  public void MarkFailed_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullCronMetricBuilder();

    // act
    var afterCall = builder.MarkFailed();

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithException_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullCronMetricBuilder();

    // act
    var afterCall = builder.WithException(new Exception());

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }

  [Test]
  public void WithSuccess_GivenCalled_ShouldReturnBuilder()
  {
    // arrange
    var builder = new NullCronMetricBuilder();

    // act
    var afterCall = builder.WithSuccess(true);

    // assert
    Assert.IsNotNull(afterCall);
    Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
    Assert.AreEqual(builder, afterCall);
  }
}