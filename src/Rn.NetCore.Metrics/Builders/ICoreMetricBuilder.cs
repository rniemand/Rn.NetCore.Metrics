using System;

namespace Rn.NetCore.Metrics.Builders;

// DOCS: docs\builders\ICoreMetricBuilder.md
public interface ICoreMetricBuilder<TBuilder>
{
  ICoreMetricBuilder<TBuilder> AddAction(Action<CoreMetric> action);
  void SetSuccess(bool success);
  CoreMetric Build();
}
