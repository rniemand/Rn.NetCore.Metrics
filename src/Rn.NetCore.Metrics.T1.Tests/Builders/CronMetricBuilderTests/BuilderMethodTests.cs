using System;
using NUnit.Framework;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Enums;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.CronMetricBuilderTests
{
  [TestFixture]
  public class BuilderMethodTests
  {
    private const string CronClass = "CronClass";
    private const string CronMethod = "CronMethod";
    private const string Category = "Category";
    private const string SubCategory = "SubCategory";

    [Test]
    public void ForCronJob_GivenClassAndMethod_ShouldSetTags()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .ForCronJob(CronClass, CronMethod)
        .Build();

      // assert
      Assert.AreEqual(CronClass, metric.Tags[CronMetricBuilder.Tags.CronClass]);
      Assert.AreEqual(CronMethod, metric.Tags[CronMetricBuilder.Tags.CronMethod]);
    }

    [Test]
    public void ForCronJob_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .ForCronJob(CronClass, CronMethod);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void WithCategory_GivenCatAndSubCat_ShouldSetTags()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithCategory(Category, SubCategory)
        .Build();

      // assert
      Assert.AreEqual(Category, metric.Tags[CronMetricBuilder.Tags.Category]);
      Assert.AreEqual(SubCategory, metric.Tags[CronMetricBuilder.Tags.SubCategory]);
    }

    [Test]
    public void WithCategory_GivenSkipToLowerFalse_ShouldSetTags()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithCategory(Category, SubCategory, false)
        .Build();

      // assert
      Assert.AreEqual(Category.LowerTrim(), metric.Tags[CronMetricBuilder.Tags.Category]);
      Assert.AreEqual(SubCategory.LowerTrim(), metric.Tags[CronMetricBuilder.Tags.SubCategory]);
    }

    [Test]
    public void WithCategory_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithCategory(Category, SubCategory);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void WithQueryCount_GivenCalled_ShouldSetField()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithQueryCount(1)
        .Build();

      // assert
      Assert.IsInstanceOf<int>(metric.Fields[CronMetricBuilder.Fields.QueryCount]);
      Assert.AreEqual(1, metric.Fields[CronMetricBuilder.Fields.QueryCount]);
    }

    [Test]
    public void WithQueryCount_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithQueryCount(1);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void IncrementQueryCount_GivenCalled_ShouldSetField()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .IncrementQueryCount(11)
        .Build();

      // assert
      Assert.IsInstanceOf<int>(metric.Fields[CronMetricBuilder.Fields.QueryCount]);
      Assert.AreEqual(11, metric.Fields[CronMetricBuilder.Fields.QueryCount]);
    }

    [Test]
    public void IncrementQueryCount_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .IncrementQueryCount(121);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void WithResultsCount_GivenCalled_ShouldSetField()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithResultsCount(12)
        .Build();

      // assert
      Assert.IsInstanceOf<int>(metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
      Assert.AreEqual(12, metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
    }

    [Test]
    public void WithResultsCount_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithResultsCount(121);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void IncrementResultsCount_GivenCalled_ShouldSetField()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .IncrementResultsCount(99)
        .Build();

      // assert
      Assert.IsInstanceOf<int>(metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
      Assert.AreEqual(99, metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
    }

    [Test]
    public void IncrementResultsCount_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .IncrementResultsCount(121);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void CountResult_GivenCalled_ShouldSetField()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        // ReSharper disable once RedundantArgumentDefaultValue
        .CountResult(null)
        .Build();

      // assert
      Assert.IsInstanceOf<int>(metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
      Assert.AreEqual(0, metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
    }

    [Test]
    public void CountResult_GivenAnyValue_ShouldSetField()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .CountResult(new ArgumentException())
        .Build();

      // assert
      Assert.IsInstanceOf<int>(metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
      Assert.AreEqual(1, metric.Fields[CronMetricBuilder.Fields.ResultsCount]);
    }

    [Test]
    public void CountResult_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .CountResult(121);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }

    [Test]
    public void WithUserId_GivenCalled_ShouldSetField()
    {
      // arrange
      var builder = new CronMetricBuilder();

      // act
      var metric = builder
        .WithUserId(2)
        .Build();

      // assert
      Assert.IsInstanceOf<int>(metric.Fields[MetricField.UserId]);
      Assert.AreEqual(2, metric.Fields[MetricField.UserId]);
    }

    [Test]
    public void WithUserId_GivenCalled_ShouldReturnBuilder()
    {
      // act
      var builder = new CronMetricBuilder()
        .WithUserId(21);

      // assert
      Assert.IsNotNull(builder);
      Assert.IsInstanceOf<ICronMetricBuilder>(builder);
    }
  }
}
