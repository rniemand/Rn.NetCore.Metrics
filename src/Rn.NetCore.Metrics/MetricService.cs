using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Outputs;

namespace Rn.NetCore.Metrics;

// DOCS: docs\MetricService.md
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


  public void Submit<TBuilder>(ICoreMetricBuilder<TBuilder> builder)
  {
    if (!_config.Enabled)
      return;

    Submit(builder.Build());
  }

  public void Submit(CoreMetric coreMetric)
  {
    if (!_config.Enabled)
      return;

    SubmitAsync(coreMetric)
      .ConfigureAwait(false)
      .GetAwaiter()
      .GetResult();
  }

  public async Task SubmitAsync(CoreMetric coreMetric)
  {
    if (!_config.Enabled)
      return;

    var finalizedMetric = FinalizeMetric(coreMetric);
    foreach (var output in _outputs)
    {
      await output.SubmitMetric(finalizedMetric);
    }
  }

  public async Task SubmitAsync<TBuilder>(ICoreMetricBuilder<TBuilder> builder)
  {
    if (!_config.Enabled)
      return;

    await SubmitAsync(builder.Build());
  }
  
  private List<IMetricOutput> LoadMetricOutputs(IEnumerable<IMetricOutput> outputs)
  {
    try
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
        enabledOutputs.Count);

      return enabledOutputs;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error loading metric outputs: {message}. {stack}",
        ex.Message,
        ex.HumanStackTrace());

      _config.Enabled = false;
      return new List<IMetricOutput>();
    }
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
