using System;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.T1.Tests.TestSupport;

public class CoreMetricBuilder
{
  private readonly CoreMetric _metric;

  public CoreMetricBuilder()
  {
    _metric = new CoreMetric("default");
  }

  public CoreMetricBuilder WithDefaults()
  {
    _metric.UpdateMeasurement("default");
    _metric.WithDate(DateTime.UtcNow);
    _metric.Tags[MetricTag.Environment] = "dev";
    _metric.Fields[MetricField.Value] = (long)0;

    return this;
  }

  public CoreMetricBuilder WithMeasurement(string measurement)
  {
    _metric.UpdateMeasurement(measurement);
    return this;
  }

  public CoreMetric Build() => _metric;

  public CoreMetric BuildWithDefaults()
    => WithDefaults().Build();
}