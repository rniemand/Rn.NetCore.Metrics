[Home](/README.md) / [Builders](/docs/builders/README.md) / ICoreMetricBuilder

# ICoreMetricBuilder
More to come...

```cs
public interface ICoreMetricBuilder<TBuilder>
{
  ICoreMetricBuilder<TBuilder> AddAction(Action<CoreMetric> action);
  void SetSuccess(bool success);
  CoreMetric Build();
}
```