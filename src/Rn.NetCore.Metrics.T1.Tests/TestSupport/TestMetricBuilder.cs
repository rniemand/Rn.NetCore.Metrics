using System;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.T1.Tests.TestSupport
{
  public class TestMetricBuilder : MetricBuilderBase
  {
    public TestMetricBuilder()
      : base("test_builder")
    { }

    public TestMetricBuilder(string measurement)
      : base(measurement)
    { }

    public TestMetricBuilder(string measurement, string source = null)
      : base(measurement, source)
    { }

    public new TestMetricBuilder SetException(Exception ex)
    {
      base.SetException(ex);
      return this;
    }

    public new TestMetricBuilder SetException(string ex)
    {
      base.SetException(ex);
      return this;
    }

    public new TestMetricBuilder SetSuccess(bool success)
    {
      base.SetSuccess(success);
      return this;
    }

    public new TestMetricBuilder SetTag(string tag, string value, bool skipToLower = false)
    {
      base.SetTag(tag, value, skipToLower);
      return this;
    }

    public new TestMetricBuilder SetTag(string tag, bool value)
    {
      base.SetTag(tag, value);
      return this;
    }

    public new TestMetricBuilder SetField(string tag, long value)
    {
      base.SetField(tag, value);
      return this;
    }

    public new TestMetricBuilder SetField(string tag, double value)
    {
      base.SetField(tag, value);
      return this;
    }

    public new TestMetricBuilder SetField(string tag, float value)
    {
      base.SetField(tag, value);
      return this;
    }

    public new TestMetricBuilder SetField(string tag, int value)
    {
      base.SetField(tag, value);
      return this;
    }

    public new TestMetricBuilder SetTag(string tag, int value)
    {
      base.SetTag(tag, value);
      return this;
    }

    public new TestMetricBuilder SetObjectTag(string tag, object value, bool skipToLower = false)
    {
      base.SetObjectTag(tag, value, skipToLower);
      return this;
    }

    public CoreMetric GetMetric() => CoreMetric;
  }
}
