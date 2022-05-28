using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;
using Rn.NetCore.Metrics.Outputs;

namespace Rn.NetCore.Metrics;

public interface IMetricService
{
  void SubmitMetric<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
  void SubmitMetric(CoreMetric coreMetric);
  Task SubmitMetricAsync(CoreMetric coreMetric);
  Task SubmitMetricAsync<TBuilder>(ICoreMetricBuilder<TBuilder> builder);
}

public class MetricService : IMetricService
{
  private readonly ILoggerAdapter<MetricService> _logger;
  private readonly IDateTimeAbstraction _dateTime;
  private readonly RnMetricsConfig _config;
  private readonly List<IMetricOutput> _outputs;


  public MetricService(
    ILoggerAdapter<MetricService> logger,
    IDateTimeAbstraction dateTime,
    IEnumerable<IMetricOutput> outputs,
    RnMetricsConfig config)
  {
    _logger = logger;
    _dateTime = dateTime;
    _config = config;

    if (!_config.Enabled)
    {
      _outputs = new List<IMetricOutput>();
      _logger.LogInformation("Metric service disabled (via config)");
      return;
    }

    _outputs = LoadMetricOutputs(outputs);
  }


  // Interface methods
  public void SubmitMetric<TBuilder>(ICoreMetricBuilder<TBuilder> builder)
  {
    if (!_config.Enabled)
      return;

    SubmitMetric(builder.Build());
  }

  public void SubmitMetric(CoreMetric coreMetric)
  {
    if (!_config.Enabled)
      return;

    SubmitMetricAsync(coreMetric)
      .ConfigureAwait(false)
      .GetAwaiter()
      .GetResult();
  }

  public async Task SubmitMetricAsync(CoreMetric coreMetric)
  {
    if (!_config.Enabled)
      return;

    var finalizedMetric = FinalizeMetric(coreMetric);
    foreach (var output in _outputs)
    {
      await output.SubmitMetric(finalizedMetric);
    }
  }

  public async Task SubmitMetricAsync<TBuilder>(ICoreMetricBuilder<TBuilder> builder)
  {
    if (!_config.Enabled)
      return;

    await SubmitMetricAsync(builder.Build());
  }


  // Internal methods
  private List<IMetricOutput> LoadMetricOutputs(IEnumerable<IMetricOutput> outputs)
  {
    var enabledOutputs = outputs.Where(x => x.Enabled).ToList();

    // No enabled outputs
    if (enabledOutputs.Count == 0)
    {
      _logger.LogWarning("No enabled outputs, disabling metric service");
      _config.Enabled = false;
      return new List<IMetricOutput>();
    }

    // We are good to go
    _logger.LogInformation("Metric service running with {count} output(s)",
      _outputs.Count);

    return enabledOutputs;
  }

  private CoreMetric FinalizeMetric(CoreMetric coreMetric)
  {
    var measurement = coreMetric.Measurement;

    if (_config.Overrides.ContainsKey(coreMetric.Measurement))
      measurement = _config.Overrides[coreMetric.Measurement];

    return coreMetric
      .WithDate(_dateTime.UtcNow)
      .SetTag("environment", _config.Environment)
      .SetTag("application", _config.Application)
      .UpdateMeasurement(GenerateMeasurement(measurement));
  }

  private string GenerateMeasurement(string measurement)
  {
    return _config.Template
      .Replace("{app}", _config.Application)
      .Replace("{measurement}", measurement);
  }
}
