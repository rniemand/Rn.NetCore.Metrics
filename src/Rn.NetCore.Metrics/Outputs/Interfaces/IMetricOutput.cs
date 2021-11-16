using System.Collections.Generic;
using System.Threading.Tasks;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Outputs
{
  public interface IMetricOutput
  {
    bool Enabled { get; }
    string Name { get; }

    Task SubmitMetric(CoreMetric metric);
    Task SubmitMetrics(List<CoreMetric> metrics);
  }
}
