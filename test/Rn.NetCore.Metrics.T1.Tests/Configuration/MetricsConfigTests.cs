using System.Collections.Generic;
using NUnit.Framework;
using Rn.NetCore.Metrics.Configuration;

namespace Rn.NetCore.Metrics.T1.Tests.Configuration;

[TestFixture]
public class MetricsConfigTests
{
  [Test]
  public void MetricsConfig_Given_ConfigKey_ShouldBe_Static()
  {
    Assert.AreEqual("Rn.Metrics", RnMetricsConfig.ConfigKey);
  }

  [Test]
  public void MetricsConfig_Given_Constructed_ShouldDefault_Enabled()
  {
    Assert.IsFalse(new RnMetricsConfig().Enabled);
  }

  [Test]
  public void MetricsConfig_Given_Constructed_ShouldDefault_Application()
  {
    Assert.AreEqual(string.Empty, new RnMetricsConfig().Application);
  }

  [Test]
  public void MetricsConfig_Given_Constructed_ShouldDefault_Template()
  {
    // act
    var config = new RnMetricsConfig();

    // assert
    Assert.AreEqual("{app}/{measurement}", config.Template);
  }

  [Test]
  public void MetricsConfig_Given_Constructed_ShouldDefault_Overrides()
  {
    // act
    var config = new RnMetricsConfig();

    // assert
    Assert.IsInstanceOf<Dictionary<string, string>>(config.Overrides);
    Assert.AreEqual(0, config.Overrides.Count);
  }

  [Test]
  public void MetricsConfig_Given_Constructed_ShouldDefault_Environment()
  {
    // act
    var config = new RnMetricsConfig();

    // assert
    Assert.AreEqual("development", config.Environment);
  }
}
