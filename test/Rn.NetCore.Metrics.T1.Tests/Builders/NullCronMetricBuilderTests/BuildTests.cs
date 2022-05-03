using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullCronMetricBuilderTests;

[TestFixture]
public class BuildTests
{
  [Test]
  public void Build_GivenCalled_ShouldReturnNull()
  {
    // arrange
    var builder = new NullCronMetricBuilder();

    // act
    var afterCall = builder.Build();

    // assert
    Assert.IsNull(afterCall);
  }
}