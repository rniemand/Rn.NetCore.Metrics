using System.Threading.Tasks;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics;

// DOCS: docs\IMetricService.md
public interface IMetricService
{
  void Submit<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
  void Submit(CoreMetric coreMetric);
  Task SubmitAsync(CoreMetric coreMetric);
  Task SubmitAsync<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
}
