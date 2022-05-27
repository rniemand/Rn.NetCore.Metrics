using System;
using System.Collections.Generic;
using Rn.NetCore.Common.Extensions;

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

  public CoreMetric SetTag(string tag, string value, bool skipToLower = true)
  {
    Tags[tag] = skipToLower ? value : value.LowerTrim();
    return this;
  }

  public CoreMetric SetField(string field, long value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, double value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, float value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, int value)
  {
    Fields[field] = value;
    return this;
  }
  
  public CoreMetric WithDate(DateTime utcTimestamp)
  {
    UtcTimestamp = utcTimestamp;
    return this;
  }
}
