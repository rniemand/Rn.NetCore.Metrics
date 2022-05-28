using System;
using System.Collections.Generic;
using System.Globalization;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.Metrics;

// DOCS: docs\CoreMetric.md
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

  public CoreMetric SetTag(string tag, string value, bool skipToLower = false)
  {
    Tags[tag] = skipToLower ? value : value.LowerTrim();
    return this;
  }

  public CoreMetric SetTag(string tag, bool value)
  {
    Tags[tag] = value ? "true" : "false";
    return this;
  }

  public CoreMetric SetTag(string tag, int value)
  {
    Tags[tag] = value.ToString("D");
    return this;
  }

  public CoreMetric SetTag(string tag, long value)
  {
    Tags[tag] = value.ToString("D");
    return this;
  }

  public CoreMetric SetTag(string tag, double value)
  {
    Tags[tag] = value.ToString(CultureInfo.InvariantCulture);
    return this;
  }

  public CoreMetric SetTag(string tag, byte value)
  {
    Tags[tag] = value.ToString(CultureInfo.InvariantCulture);
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

  public CoreMetric SetField(string field, bool value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, sbyte value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, byte value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, short value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, ushort value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, uint value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, ulong value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, decimal value)
  {
    Fields[field] = value;
    return this;
  }

  public CoreMetric SetField(string field, TimeSpan value)
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
