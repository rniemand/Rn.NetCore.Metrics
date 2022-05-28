using System.Collections.Generic;
using System.Threading.Tasks;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Outputs;

public class ConsoleMetricOutput : IMetricOutput
{
  public bool Enabled { get; }
  public string Name => nameof(ConsoleMetricOutput);

  public ConsoleMetricOutput()
  {
    Enabled = false;
  }

  public Task SubmitMetric(CoreMetric metric)
  {
    throw new System.NotImplementedException();
  }

  public Task SubmitMetrics(List<CoreMetric> metrics)
  {
    throw new System.NotImplementedException();
  }
}
