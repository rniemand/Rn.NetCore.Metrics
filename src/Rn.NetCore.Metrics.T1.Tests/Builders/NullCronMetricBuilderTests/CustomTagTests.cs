using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullCronMetricBuilderTests
{
  [TestFixture]
  public class CustomTagTests
  {
    [Test]
    public void WithCustomTag1_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomTag1("value");

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomTag2_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomTag2("value");

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomTag3_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomTag3("value");

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomTag4_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomTag4("value");

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }
  }
}
