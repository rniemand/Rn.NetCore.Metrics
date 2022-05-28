[Home](/README.md) / IMetricService

# IMetricService
More to come...

```cs
public interface IMetricService
{
  void SubmitMetric<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
  void SubmitMetric(CoreMetric coreMetric);
  Task SubmitMetricAsync(CoreMetric coreMetric);
  Task SubmitMetricAsync<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
}
```