[Home](/README.md) / CoreMetric

# CoreMetric
More to come...

```cs
public class CoreMetric
{
  public string Measurement { get; private set; }
  public DateTime UtcTimestamp { get; private set; }
  public Dictionary<string, string> Tags { get; }
  public Dictionary<string, object> Fields { get; }

  public CoreMetric(string measurement) { }

  public CoreMetric UpdateMeasurement(string measurement) { }

  public CoreMetric SetTag(/* ... */) { }

  public CoreMetric SetField(/* ... */) { }

  public CoreMetric WithDate(DateTime utcTimestamp) { }
}
```