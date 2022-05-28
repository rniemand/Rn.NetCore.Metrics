using System;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders;

public interface ICoreMetricBuilder<TBuilder>
{
  ICoreMetricBuilder<TBuilder> AddAction(Action<CoreMetric> action);
  void SetSuccess(bool success);
  CoreMetric Build();
}
