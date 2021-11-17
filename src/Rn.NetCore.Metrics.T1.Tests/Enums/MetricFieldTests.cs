using NUnit.Framework;
using Rn.NetCore.Metrics.Enums;

namespace Rn.NetCore.Metrics.T1.Tests.Enums
{
  [TestFixture]
  public class MetricFieldTests
  {
    [Test]
    public void Value_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("value", MetricField.Value);
    }

    [Test]
    public void CallCount_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("call_count", MetricField.CallCount);
    }

    [Test]
    public void UserId_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("user_id", MetricField.UserId);
    }

    [Test]
    public void Int1_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_int1", MetricField.Int1);
    }

    [Test]
    public void Int2_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_int2", MetricField.Int2);
    }

    [Test]
    public void Int3_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_int3", MetricField.Int3);
    }

    [Test]
    public void Int4_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_int4", MetricField.Int4);
    }

    [Test]
    public void Int5_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_int5", MetricField.Int5);
    }

    [Test]
    public void Long1_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_long1", MetricField.Long1);
    }

    [Test]
    public void Long2_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_long2", MetricField.Long2);
    }

    [Test]
    public void Long3_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_long3", MetricField.Long3);
    }

    [Test]
    public void Timing1_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_timing1", MetricField.Timing1);
    }

    [Test]
    public void Timing2_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_timing2", MetricField.Timing2);
    }

    [Test]
    public void Timing3_GivenCalled_ShouldReturn_ExpectedValue()
    {
      Assert.AreEqual("custom_timing3", MetricField.Timing3);
    }
  }
}
