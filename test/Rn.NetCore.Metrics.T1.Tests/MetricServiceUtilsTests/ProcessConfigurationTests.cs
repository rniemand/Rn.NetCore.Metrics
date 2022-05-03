﻿using NUnit.Framework;
using Rn.NetCore.Metrics.Exceptions;
using Rn.NetCore.Metrics.T1.Tests.TestSupport;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceUtilsTests;

[TestFixture]
public class ProcessConfigurationTests
{
  [Test]
  public void ProcessConfiguration_GivenDisabled_ShouldDoNothing()
  {
    // arrange
    var config = new MetricsConfigBuilder()
      .WithDefaults()
      .WithEnabled(false)
      .WithApplication(null)
      .Build();

    // assert
    Assert.DoesNotThrow(() => MetricServiceUtils.ProcessConfiguration(config));
  }

  [Test]
  public void ProcessConfiguration_GivenInvalidAppName_ShouldThrow()
  {
    // arrange
    var config = new MetricsConfigBuilder()
      .WithDefaults()
      .WithEnabled(true)
      .WithApplication(null)
      .Build();

    // act
    var ex = Assert.Throws<MetricConfigException>(() =>
      MetricServiceUtils.ProcessConfiguration(config)
    );

    // assert
    Assert.IsNotNull(ex);
    Assert.IsInstanceOf<MetricConfigException>(ex);
    Assert.AreEqual("ApplicationName is required", ex.Message);
  }

  [Test]
  public void ProcessConfiguration_GivenNoEnvironment_ShouldSetDefault()
  {
    // arrange
    var config = new MetricsConfigBuilder()
      .WithDefaults()
      .WithEnabled(true)
      .WithEnvironment(null)
      .Build();

    // act
    Assert.IsNull(config.Environment);
    MetricServiceUtils.ProcessConfiguration(config);

    // assert
    Assert.AreEqual("development", config.Environment);
  }

  [Test]
  public void ProcessConfiguration_GivenNoTemplate_ShouldSetDefault()
  {
    // arrange
    var config = new MetricsConfigBuilder()
      .WithDefaults()
      .WithEnabled(true)
      .WithTemplate(null)
      .Build();

    // act
    Assert.IsNull(config.Template);
    MetricServiceUtils.ProcessConfiguration(config);

    // assert
    Assert.AreEqual("{app}/{measurement}", config.Template);
  }

  [Test]
  public void ProcessConfiguration_GivenApplicationName_ShouldNormalize()
  {
    // arrange
    var config = new MetricsConfigBuilder()
      .WithDefaults()
      .WithEnabled(true)
      .WithApplication("HELLO")
      .Build();

    // act
    MetricServiceUtils.ProcessConfiguration(config);

    // assert
    Assert.AreEqual("hello", config.Application);
  }

  [Test]
  public void ProcessConfiguration_GivenEnvironment_ShouldNormalize()
  {
    // arrange
    var config = new MetricsConfigBuilder()
      .WithDefaults()
      .WithEnabled(true)
      .WithEnvironment("PRODUCTION")
      .Build();

    // act
    MetricServiceUtils.ProcessConfiguration(config);

    // assert
    Assert.AreEqual("production", config.Environment);
  }
}