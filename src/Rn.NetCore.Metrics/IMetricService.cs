using System.Threading.Tasks;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics;

// DOCS: docs\IMetricService.md
public interface IMetricService
{
  void SubmitMetric<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
  void SubmitMetric(CoreMetric coreMetric);
  Task SubmitMetricAsync(CoreMetric coreMetric);
  Task SubmitMetricAsync<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
}
