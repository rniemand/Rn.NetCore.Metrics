#nullable enable
using System;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders;

[TestFixture]
public class CronMetricBuilderTests
{
  private const string CronMethod = "CronMethod";
  private const string CronClass = "CronClass";
  private const string Category = "Category";
  private const string SubCategory = "SubCategory";

  [Test]
  public void CronMetricBuilder_GivenNoConstructorOverloads_ShouldConstructWithDefaults()
  {
    // Act
    var metric = new CronMetricBuilder().Build();

    // Assert
    Assert.That(metric.Tags["cron_class"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["cron_method"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["sub_category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["success"], Is.EqualTo("true"));
    Assert.That(metric.Tags["has_ex"], Is.EqualTo("false"));
    Assert.That(metric.Tags["ex_name"], Is.EqualTo(string.Empty));
    Assert.That(metric.Measurement, Is.EqualTo("cron_job"));
  }

  [Test]
  public void CronMetricBuilder_GivenMethodClassConstructor_ShouldConstructWithDefaults()
  {
    // Act
    var metric = new CronMetricBuilder(CronClass, CronMethod).Build();

    // Assert
    Assert.That(metric.Tags["cron_class"], Is.EqualTo(CronClass));
    Assert.That(metric.Tags["cron_method"], Is.EqualTo(CronMethod));
    Assert.That(metric.Tags["category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["sub_category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["success"], Is.EqualTo("true"));
    Assert.That(metric.Tags["has_ex"], Is.EqualTo("false"));
    Assert.That(metric.Tags["ex_name"], Is.EqualTo(string.Empty));
    Assert.That(metric.Measurement, Is.EqualTo("cron_job"));
  }

  [Test]
  public void ForCronJob_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new CronMetricBuilder()
      .ForCronJob(CronClass, CronMethod)
      .Build();

    // Assert
    Assert.That(metric.Tags["cron_class"], Is.EqualTo(CronClass));
    Assert.That(metric.Tags["cron_method"], Is.EqualTo(CronMethod));
  }

  [Test]
  public void WithCategory_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new CronMetricBuilder()
      .WithCategory(Category, SubCategory)
      .Build();

    // Assert
    Assert.That(metric.Tags["category"], Is.EqualTo(Category));
    Assert.That(metric.Tags["sub_category"], Is.EqualTo(SubCategory));
  }

  [Test]
  public void WithException_GivenCalled_ShouldSetAppropriateFields()
  {
    // Arrange
    var ex = new Exception("Whoops");

    // Act
    var metric = new CronMetricBuilder()
      .WithException(ex)
      .Build();

    // Assert
    Assert.That(metric.Tags["success"], Is.EqualTo("false"));
    Assert.That(metric.Tags["has_ex"], Is.EqualTo("true"));
    Assert.That(metric.Tags["ex_name"], Is.EqualTo("Exception"));
  }

  [Test]
  public void WithQueryCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new CronMetricBuilder()
      .WithQueryCount(1)
      .Build();

    // Assert
    Assert.That(metric.Fields["query_count"], Is.EqualTo(1));
  }

  [Test]
  public void IncrementQueryCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new CronMetricBuilder()
      .IncrementQueryCount(3)
      .IncrementQueryCount()
      .Build();

    // Assert
    Assert.That(metric.Fields["query_count"], Is.EqualTo(4));
  }

  [Test]
  public void WithResultsCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new CronMetricBuilder()
      .WithResultsCount(10)
      .Build();

    // Assert
    Assert.That(metric.Fields["results_count"], Is.EqualTo(10));
  }

  [Test]
  public void IncrementResultsCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new CronMetricBuilder()
      .IncrementResultsCount(10)
      .IncrementResultsCount(2)
      .Build();

    // Assert
    Assert.That(metric.Fields["results_count"], Is.EqualTo(12));
  }

  [TestCase(null, 0)]
  [TestCase(16, 1)]
  public void CountResult_GivenCalled_ShouldSetAppropriateFields(object? result, int expected)
  {
    // Act
    var metric = new CronMetricBuilder()
      .CountResult(result)
      .Build();

    // Assert
    Assert.That(metric.Fields["results_count"], Is.EqualTo(expected));
  }
}
