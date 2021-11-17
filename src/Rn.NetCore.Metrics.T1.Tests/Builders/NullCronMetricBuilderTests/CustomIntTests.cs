using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullCronMetricBuilderTests
{
  [TestFixture]
  public class CustomIntTests
  {
    [Test]
    public void WithCustomInt1_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt1(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomInt2_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt2(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomInt3_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt3(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }


    [Test]
    public void IncrementCustomInt1_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt1(12);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementCustomInt2_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt2(12);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementCustomInt3_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt3(12);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }
  }
}
