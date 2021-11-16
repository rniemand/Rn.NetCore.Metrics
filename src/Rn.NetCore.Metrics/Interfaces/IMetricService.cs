using System.Threading.Tasks;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Interfaces
{
  public interface IMetricService
  {
    void SubmitBuilder(IMetricBuilder builder);
    Task SubmitBuilderAsync(IMetricBuilder builder);
    void SubmitMetric(CoreMetric coreMetric);
    Task SubmitMetricAsync(CoreMetric coreMetric);
  }
}