using System;
using System.Collections.Generic;

namespace Rn.NetCore.Metrics.Models;

public class CoreMetric
{
  public string Measurement { get; private set; }
  public DateTime UtcTimestamp { get; private set; }
  public Dictionary<string, string> Tags { get; }
  public Dictionary<string, object> Fields { get; }

  public CoreMetric(string measurement)
  {
    Measurement = measurement;
    UtcTimestamp = DateTime.MinValue;
    Tags = new Dictionary<string, string>();
    Fields = new Dictionary<string, object>();
  }

  public CoreMetric UpdateMeasurement(string measurement)
  {
    Measurement = measurement;
    return this;
  }

  public CoreMetric SetTag(string tag, string value)
  {
    Tags[tag] = value;
    return this;
  }

  public CoreMetric WithDate(DateTime utcTimestamp)
  {
    UtcTimestamp = utcTimestamp;
    return this;
  }
}
