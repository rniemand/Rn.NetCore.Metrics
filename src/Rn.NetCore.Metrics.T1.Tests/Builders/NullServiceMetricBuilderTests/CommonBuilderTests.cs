using System;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests
{
  [TestFixture]
  public class CommonBuilderTests
  {
    [Test]
    public void WithException_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.WithException(new Exception());

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void MarkFailed_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.MarkFailed();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void MarkSuccess_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.MarkSuccess();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithSuccess_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.WithSuccess(true);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }
  }
}
