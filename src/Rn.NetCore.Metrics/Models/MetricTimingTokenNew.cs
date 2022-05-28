using System;
using System.Diagnostics;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.Models;

public class MetricTimingTokenNew<TBuilder> : IMetricTimingToken
{
  public string FieldName { get; private set; }

  private readonly ICoreMetricBuilder<TBuilder> _builder;
  private readonly Stopwatch _stopwatch;

  public MetricTimingTokenNew(ICoreMetricBuilder<TBuilder> builder, string fieldName)
  {
    _builder = builder;
    FieldName = fieldName;
    _stopwatch = Stopwatch.StartNew();
  }

  public void Dispose()
  {
    var elapsedMs = _stopwatch.ElapsedMilliseconds;
    _builder.AddAction(m => { m.SetField(FieldName, elapsedMs); });
    GC.SuppressFinalize(this);
  }
}
