using NUnit.Framework;
using Rn.NetCore.Common.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests
{
  [TestFixture]
  public class CustomIntTests
  {
    [Test]
    public void WithCustomInt1_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt1(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomInt2_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt2(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomInt3_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt3(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomInt4_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt4(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCustomInt5_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.WithCustomInt5(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }


    [Test]
    public void IncrementCustomInt1_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt1();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementCustomInt2_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt2();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementCustomInt3_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt3();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementCustomInt4_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt4();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementCustomInt5_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullServiceMetricBuilder();

      // act
      var afterCall = builder.IncrementCustomInt5();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<NullServiceMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }
  }
}
