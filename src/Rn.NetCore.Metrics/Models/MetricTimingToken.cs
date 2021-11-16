using System.Diagnostics;
using Rn.NetCore.Metrics.Enums;

namespace Rn.NetCore.Metrics.Models
{
  public class MetricTimingToken : IMetricTimingToken
  {
    public string FieldName { get; private set; }

    private readonly CoreMetric _metric;
    private readonly Stopwatch _stopwatch;

    public MetricTimingToken(CoreMetric metric, string fieldName)
    {
      _metric = metric;
      FieldName = fieldName;

      // If there was no field name provided, fall back to "value"
      if (string.IsNullOrWhiteSpace(FieldName))
        FieldName = MetricField.Value;

      _stopwatch = Stopwatch.StartNew();
    }

    public void Dispose()
    {
      _metric.Fields[FieldName] = _stopwatch.ElapsedMilliseconds;
    }
  }
}
