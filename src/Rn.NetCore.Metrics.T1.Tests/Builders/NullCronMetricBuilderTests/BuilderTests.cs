using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullCronMetricBuilderTests
{
  [TestFixture]
  public class BuilderTests
  {
    [Test]
    public void ForCronJob_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.ForCronJob("class","method");

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithCategory_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithCategory("cat", "subCat");

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithQueryCount_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithQueryCount(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementQueryCount_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.IncrementQueryCount();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithResultsCount_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithResultsCount(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void IncrementResultsCount_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.IncrementResultsCount();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void CountResult_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.CountResult();

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }

    [Test]
    public void WithUserId_GivenCalled_ShouldReturnBuilder()
    {
      // arrange
      var builder = new NullCronMetricBuilder();

      // act
      var afterCall = builder.WithUserId(1);

      // assert
      Assert.IsNotNull(afterCall);
      Assert.IsInstanceOf<ICronMetricBuilder>(afterCall);
      Assert.AreEqual(builder, afterCall);
    }
  }
}
