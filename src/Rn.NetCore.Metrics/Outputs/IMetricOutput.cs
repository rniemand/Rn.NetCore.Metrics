using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rn.NetCore.Metrics.Outputs;

// DOCS: docs\outputs\IMetricOutput.md
public interface IMetricOutput
{
  bool Enabled { get; }
  string Name { get; }

  Task SubmitMetric(CoreMetric metric);
  Task SubmitMetrics(List<CoreMetric> metrics);
}
