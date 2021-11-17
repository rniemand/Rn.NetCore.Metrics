using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullCronMetricBuilderTests
{
  [TestFixture]
  public class ConstructorTests
  {
    [Test]
    public void Constructor_GivenCalled_ShouldInheritExpectedInterfaces()
    {
      // act
      var builder = new NullCronMetricBuilder();

      // assert
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
      Assert.IsInstanceOf<IMetricBuilder>(builder);
    }

    [Test]
    public void Constructor_GivenCalled_ShouldSetProperties()
    {
      // act
      var builder = new NullCronMetricBuilder();

      // assert
      Assert.IsTrue(builder.IsNullMetricBuilder);
    }
  }
}
