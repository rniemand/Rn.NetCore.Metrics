using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders
{
  public interface IMetricBuilder
  {
    public bool IsNullMetricBuilder { get; }

    public CoreMetric Build();
  }
}