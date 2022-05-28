[Home](/README.md) / MetricService

# MetricService
More to come...

```cs
public class MetricService : IMetricService
{
  public void SubmitMetric<TBuilder>(ICoreMetricBuilder<TBuilder> builder) { }

  public void SubmitMetric(CoreMetric coreMetric) { }

  // ...
}
```