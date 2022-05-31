using System;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Builders;

[TestFixture]
public class ServiceMetricBuilderTests
{
  [Test]
  public void Constructor_GivenNoOverloads_ShouldSetDefaultFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .Build();

    // Assert
    Assert.That(metric.Tags["service_name"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["service_method"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["sub_category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["success"], Is.EqualTo("true"));
    Assert.That(metric.Tags["has_ex"], Is.EqualTo("false"));
    Assert.That(metric.Tags["ex_name"], Is.EqualTo(string.Empty));
    Assert.That(metric.Measurement, Is.EqualTo("service_call"));
  }

  [Test]
  public void Constructor_GivenServiceNameAndMethod_ShouldSetDefaultFields()
  {
    // Act
    var metric = new ServiceMetricBuilder("Service", "Method")
      .Build();

    // Assert
    Assert.That(metric.Tags["service_name"], Is.EqualTo("Service"));
    Assert.That(metric.Tags["service_method"], Is.EqualTo("Method"));
    Assert.That(metric.Tags["category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["sub_category"], Is.EqualTo(string.Empty));
    Assert.That(metric.Tags["success"], Is.EqualTo("true"));
    Assert.That(metric.Tags["has_ex"], Is.EqualTo("false"));
    Assert.That(metric.Tags["ex_name"], Is.EqualTo(string.Empty));
    Assert.That(metric.Measurement, Is.EqualTo("service_call"));
  }

  [Test]
  public void ForService_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .ForService("Service", "Method")
      .Build();

    // Assert
    Assert.That(metric.Tags["service_name"], Is.EqualTo("Service"));
    Assert.That(metric.Tags["service_method"], Is.EqualTo("Method"));
  }

  [Test]
  public void WithCategory_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .WithCategory("Category", "SubCategory")
      .Build();

    // Assert
    Assert.That(metric.Tags["category"], Is.EqualTo("Category"));
    Assert.That(metric.Tags["sub_category"], Is.EqualTo("SubCategory"));
  }

  [Test]
  public void WithQueryCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .WithQueryCount(1)
      .Build();

    // Assert
    Assert.That(metric.Fields["query_count"], Is.EqualTo(1));
  }

  [Test]
  public void IncrementQueryCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .IncrementQueryCount(21)
      .IncrementQueryCount()
      .Build();

    // Assert
    Assert.That(metric.Fields["query_count"], Is.EqualTo(22));
  }

  [Test]
  public void WithResultsCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .WithResultsCount(21)
      .Build();

    // Assert
    Assert.That(metric.Fields["results_count"], Is.EqualTo(21));
  }

  [Test]
  public void IncrementResultsCount_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .IncrementResultsCount(11)
      .IncrementResultsCount(2)
      .IncrementResultsCount()
      .Build();

    // Assert
    Assert.That(metric.Fields["results_count"], Is.EqualTo(14));
  }

  [Test]
  public void CountResult_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .CountResult(null)
      .CountResult(11)
      .Build();

    // Assert
    Assert.That(metric.Fields["results_count"], Is.EqualTo(1));
  }

  [Test]
  public void WithException_GivenCalled_ShouldSetAppropriateFields()
  {
    // Act
    var metric = new ServiceMetricBuilder()
      .WithException(new Exception("Whoops"))
      .Build();

    // Assert
    Assert.That(metric.Tags["success"], Is.EqualTo("false"));
    Assert.That(metric.Tags["has_ex"], Is.EqualTo("true"));
    Assert.That(metric.Tags["ex_name"], Is.EqualTo("Exception"));
  }
}
