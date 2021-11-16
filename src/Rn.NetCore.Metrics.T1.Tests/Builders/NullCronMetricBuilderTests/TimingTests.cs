using NUnit.Framework;
using Rn.NetCore.Common.Metrics.Builders;
using Rn.NetCore.Common.Metrics.Interfaces;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullCronMetricBuilderTests
{
  [TestFixture]
  public class TimingTests
  {
    [Test]
    public void WithTiming_GivenCalled_ShouldReturnTimingToken()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithTiming();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<IMetricTimingToken>(afterCall);
    }

    [Test]
    public void WithCustomTiming1_GivenCalled_ShouldReturnTimingToken()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomTiming1();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<IMetricTimingToken>(afterCall);
    }

    [Test]
    public void WithCustomTiming2_GivenCalled_ShouldReturnTimingToken()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomTiming2();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<IMetricTimingToken>(afterCall);
    }

    [Test]
    public void WithCustomTiming3_GivenCalled_ShouldReturnTimingToken()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCustomTiming3();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<IMetricTimingToken>(afterCall);
    }
  }
}
