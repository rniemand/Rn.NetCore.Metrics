using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests;

[TestFixture]
public class ConstructorTests
{
  [Test]
  public void NullServiceMetricBuilder_Given_Constructed_ShouldInherit_ExpectedInterfaces()
  {
    // act
    var builder = new NullServiceMetricBuilder();

    // assert
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
    Assert.IsInstanceOf<IMetricBuilder>(builder);
  }

  [Test]
  public void NullServiceMetricBuilder_Given_Constructed_ShouldSet_Properties()
  {
    // act
    var builder = new NullServiceMetricBuilder();

    // assert
    Assert.IsTrue(builder.IsNullMetricBuilder);
  }
}