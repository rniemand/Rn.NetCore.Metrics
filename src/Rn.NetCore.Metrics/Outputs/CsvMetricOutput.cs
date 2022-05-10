using System.Collections.Generic;
using System.Threading.Tasks;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Outputs;

public class CsvMetricOutput : IMetricOutput
{
  public bool Enabled { get; private set; }
  public string Name { get; }
    
  public CsvMetricOutput()
  {
    Name = nameof(CsvMetricOutput);
    Enabled = false;
  }

  public async Task SubmitMetric(CoreMetric metric) => await Task.CompletedTask;
  public async Task SubmitMetrics(List<CoreMetric> metrics) => await Task.CompletedTask;
}
