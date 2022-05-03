using NUnit.Framework;
using Rn.NetCore.Metrics.Enums;

namespace Rn.NetCore.Metrics.T1.Tests.Enums;

[TestFixture]
public class MetricTagTests
{
  [Test]
  public void Source_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("source", MetricTag.Source);
  }

  [Test]
  public void Success_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("success", MetricTag.Success);
  }

  [Test]
  public void HasException_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("has_ex", MetricTag.HasException);
  }

  [Test]
  public void ExceptionName_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("ex_name", MetricTag.ExceptionName);
  }

  [Test]
  public void Environment_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("environment", MetricTag.Environment);
  }

  [Test]
  public void Application_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("application", MetricTag.Application);
  }

  [Test]
  public void Tag1_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("custom_tag1", MetricTag.Tag1);
  }

  [Test]
  public void Tag2_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("custom_tag2", MetricTag.Tag2);
  }

  [Test]
  public void Tag3_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("custom_tag3", MetricTag.Tag3);
  }

  [Test]
  public void Tag4_GivenCalled_ShouldReturn_ExpectedValue()
  {
    Assert.AreEqual("custom_tag4", MetricTag.Tag4);
  }
}