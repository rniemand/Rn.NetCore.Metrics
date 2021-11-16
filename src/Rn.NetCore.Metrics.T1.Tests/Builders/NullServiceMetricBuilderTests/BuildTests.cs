using NUnit.Framework;
using Rn.NetCore.Common.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests
{
  [TestFixture]
  public class BuildTests
  {
    [Test]
    public void Build_GivenCalled_ShouldReturnNull()
    {
      // act
      var builder = new NullServiceMetricBuilder();

      // assert
      Assert.IsNull(builder.Build());
    }
  }
}
