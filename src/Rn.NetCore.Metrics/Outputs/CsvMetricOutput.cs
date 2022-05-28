using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rn.NetCore.Metrics.Outputs;

// DOCS: docs\outputs\CsvMetricOutput.md
public class CsvMetricOutput : IMetricOutput
{
  public bool Enabled { get; private set; }
  public string Name { get; }
    
  public CsvMetricOutput()
  {
    Name = nameof(CsvMetricOutput);
    Enabled = false;
  }

  public async Task SubmitMetric(CoreMetric metric) =>
    await Task.CompletedTask;

  public async Task SubmitMetrics(List<CoreMetric> metrics) =>
    await Task.CompletedTask;
}
